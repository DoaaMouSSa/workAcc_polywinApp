import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, Col, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import Select from "react-select";
import '../../Design/CSS/custom.css';

// validation of field
const schema = Yup.object({
    descount: Yup.string().required("برجاء إدخال نسبة الخصم"),
    // CategoryTypeName: Yup.string().required("برجاء الأختيار نوع الملف"),
});


class Descount extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/System/DashBoard");
        }

        // this is columns of Department
        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <div>
                            <Form.Check
                                checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
                                onChange={() => this.toggleRow(rowInfo.original.id)} />
                        </div>
                    );
                },
                sortable: false,
                width: 250
            },
            {
                Header: <strong> نوع العميل </strong>,
                accessor: 'typeOfDescountName',
                width: 150,
                filterable: true,
            },
            {
                Header: <strong> نوع القسم </strong>,
                accessor: 'typeofCategoryName',
                width: 220,
                filterable: true,
            },
            {
                Header: <strong> نسبة الخصم </strong>,
                accessor: 'descount',
                width: 220,
                filterable: true,
            },
            {
                Header: <strong> نوع الخصم </strong>,
                accessor: 'typeDescountName',
                width: 220,
                filterable: true,
            }
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            name: "",
            id: 0,
            show: false,
            showImage: false,
            listTypeClient: [
                { value: 2, label: "وكيل" },
                { value: 3, label: "ورشة" }
            ],
            objDescount: {
                Id: 0,
                typeOfDescountName: "",
                typeofCategory: "",
                descount: "",
                type: "true"
            }
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListDescount && nextState.ListDescount.length > 0) {
            this.setState({
                isLoading: false,
                show: false
            });
        } else {
            this.setState({
                isLoading: false,
                show: false
            });
        }
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.getAllDescount();
        this.props.actions.getAllParentProductCategoryForDrop();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            objDescount: {
                Id: 0,
                typeOfDescountName: "",
                typeofCategory: "",
                descount: "",
                type: "true"
            }
        });
    }

    showDeleteModal() {
        this.setState({
            showConfirme: true
        });
    }


    // this function when close modal
    handleClose() {
        this.setState({
            show: false,
            showImage: false,
            showConfirme: false
        });
    }

    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.deleteDescount(this.state.selected);
    }

    // this function when leave from page
    componentWillUnmont() {
        this.setState({
            show: false,
            isLoading: false,
            showConfirme: false
        });
    }

    toggleRow(id) {
        const isAdd = this.state.selected.indexOf(id);

        let newSelected = this.state.selected;

        if (isAdd > -1) {
            newSelected.splice(isAdd, 1);
        } else {

            newSelected.push(id);
        }

        this.setState({
            selected: newSelected
        });
    }

    editCategoryGallery = (state, rowInfo, column, instance) => {

        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
                    let obj = this.state.objDescount;


                    obj.typeOfDescount = { value: rowInfo.original.typeOfDescount, label: rowInfo.original.typeOfDescountName };
                    obj.typeOfCategory = { value: rowInfo.original.typeofCategory, label: rowInfo.original.typeofCategoryName };
                    obj.descount = rowInfo.original.descount;
                    obj.type = rowInfo.original.typeDescountName === "نسبة مئوية" ? "true" : "false";
                    obj.Id = rowInfo.original.id;

                    this.setState({
                        objDescount: obj,
                        show: true
                    });
                }
            }
        };
    };

    addEditCategoryGallery = (value) => {
        this.setState({
            isLoading: true
        });

        let obj = {};
        obj.id = value.Id;
        obj.TypeOfDescount = value.typeOfDescount.value;
        obj.TypeOfCategory = value.typeOfCategory.value;
        obj.Descount = value.descount;
        obj.TypeDescount = this.state.objDescount.type === "true" ? true:false;

        this.props.actions.addEditDescount(obj);
    }

    handleChangeCheck = (e) => {
        let originalDescount = this.state.objDescount;

        originalDescount.type = e.target.value;

        this.setState({
            objDescount: originalDescount
        });
    }

    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">تسجيل نسبة الخصم</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            <Button size="lg" onClick={this.showModal.bind(this)}>إضافة</Button>
                            {this.state.selected.length > 0 ?
                                <Button size="lg" onClick={this.showDeleteModal.bind(this)}>حذف</Button>
                                : null}
                        </div>
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editCategoryGallery}
                            data={this.props.ListDescount}
                            columns={this.cells}
                        />
                    </div>
                </div>
                <Modal show={this.state.show} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        إضافة أو تعديل
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} enableReinitialize={true}
                            onSubmit={(values) => {
                                this.addEditCategoryGallery(values)
                            }}
                            initialValues={{
                                Id: this.state.objDescount.Id,
                                typeOfCategory: this.state.objDescount.typeOfCategory,
                                typeOfDescount: this.state.objDescount.typeOfDescount,
                                descount: this.state.objDescount.descount,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="typeOfCategory">
                                        <Form.Label>الأقسام</Form.Label>
                                        <Select
                                            name="typeOfCategory"
                                            id="typeOfCategory"
                                            value={values.typeOfCategory}
                                            onChange={(opt) => {
                                                setFieldValue("typeOfCategory", opt);
                                            }}
                                            options={this.props.ListParentProductCategoryForDrop}
                                            onBlur={handleBlur}
                                            error={errors.typeOfCategory}
                                            touched={touched.typeOfCategory}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.typeOfCategory}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="typeOfDescount">
                                        <Form.Label>العملاء</Form.Label>
                                        <Select
                                            name="typeOfDescount"
                                            id="typeOfDescount"
                                            value={values.typeOfDescount}
                                            onChange={(opt) => {
                                                setFieldValue("typeOfDescount", opt);
                                            }}
                                            options={this.state.listTypeClient}
                                            onBlur={handleBlur}
                                            error={errors.typeOfDescount}
                                            touched={touched.typeOfDescount}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.typeOfDescount}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="descount">
                                        <Form.Label>نسبة الخصم</Form.Label>
                                        <Form.Control type="number"
                                            style={{ height: "50px" }}
                                            placeholder="نسبة الخصم"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="descount"
                                            autoComplete="off"
                                            value={values.descount}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.descount}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.descount}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Col>
                                        <Form.Group>
                                            <Form.Label as="legend" column xs={12}>
                                                النوع
                                            </Form.Label>
                                            <Col sm={10}>
                                                <Form.Check inline
                                                    type="radio"
                                                    value={"true"}
                                                    defaultChecked={this.state.objDescount.type === "true"}
                                                    label="نسبة مئوية"
                                                    name="isActive"
                                                    onChange={this.handleChangeCheck}
                                                />
                                                <Form.Check inline
                                                    type="radio"
                                                    value={"false"}
                                                    defaultChecked={this.state.objDescount.type === "false"}
                                                    label="رقم صحيح"
                                                    name="isActive"
                                                    onChange={this.handleChangeCheck}
                                                />
                                            </Col>
                                        </Form.Group>
                                    </Col>
                                    <div style={{ direction: "ltr" }}>
                                        <Button size="lg" onClick={this.handleClose.bind(this)} style={{ marginRight: '10px' }}>
                                            غلق
                                                </Button>
                                        {this.state.isLoading ? <Button size="lg" disabled>
                                            <Spinner
                                                as="span"
                                                animation="grow"
                                                size="sm"
                                                role="status"
                                                aria-hidden="true"
                                            />
                                                   تحميل
                                                </Button> :
                                            <Button size="lg" variant="success" type="submit">
                                                حفظ
                                                    </Button>}
                                    </div>
                                </Form>
                            )}
                        </Formik>
                    </Modal.Body>
                </Modal>
                {this.state.showConfirme ? <Confirme text="هل تريد الحذف ?" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListDescount: state.reduces.ListDescount,
    ListParentProductCategoryForDrop: state.reduces.ListParentProductCategoryForDrop
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Descount);