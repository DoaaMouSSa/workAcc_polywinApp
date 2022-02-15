import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import Select from "react-select";
import '../../Design/CSS/custom.css';

// validation of field
const schema = Yup.object({
    Name: Yup.string().required("برجاء إدخال اسم الخزينه").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});

class Bank extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/System/Login");
        }

        // this is columns of Bank
        this.cells = [
            //{
            //    Header: "",
            //    id: "checkbox",
            //    accessor: "",
            //    Cell: (rowInfo) => {
            //        return (
            //            <div>
            //                <Form.Check
            //                    checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
            //                    onChange={() => this.toggleRow(rowInfo.original.id)} />
            //            </div>
            //        );
            //    },
            //    sortable: false,
            //    width: 30
            //},
            {
                Header: <strong> اسم الحساب </strong>,
                accessor: 'name',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong> العمله  </strong>,
                accessor: 'currency',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong>الرصيد</strong>,
                accessor: 'balance',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong>التاريخ</strong>,
                accessor: 'date',
                width: 150,
                filterable: true,
            },
            {
                Header: <strong>نوع العمليه</strong>,
                accessor: 'orderType',
                width: 120,
                filterable: true,
            }, {
                Header: <strong>الوارد</strong>,
                accessor: 'in',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong>القيمه المدفوعه</strong>,
                accessor: 'out',
                width: 120,
                filterable: true,
            },
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            id: 0,
            Name: "",
            currency: "",

        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListBank && nextState.ListBank.length > 0) {

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
        this.props.actions.getAllBank();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,

            Id: 0,
            Name: "",
            type: "",
            currency:"",
        });
    }

    //showDeleteModal() {
    //    this.setState({
    //        showConfirme: true
    //    });
    //}


    // this function when close modal
    handleClose() {
        this.setState({
            show: false,
            showConfirme: false,
            isLoading: false
        });
    }

    // this function when submit Delete item
    //handleConfirm = () => {
    //    this.setState({
    //        showConfirme: false,
    //        selected: []
    //    });

    //    this.props.actions.DeleteBank(this.state.selected);
    //}

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

    //editBank = (state, rowInfo, column, instance) => {
    //    const { selection } = this.state;
    //    return {
    //        onClick: (e, handleOriginal) => {
    //            if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
    //                this.setState({
    //                    id: rowInfo.original.id,
    //                    Name: rowInfo.original.Name,
    //                    type: rowInfo.original.type,
    //                    currency: rowInfo.original.currency,
    //                    show: true
    //                });

    //            }
    //        }
    //    };
    //};
    //addeditBank = (value) => {
    //    this.setState({
    //        isLoading: true
    //    });

    //    if (value.id > 0) {
    //        let obj = {};
    //        obj.id = value.id;
    //        obj.name = value.Name;
    //        obj.type = value.type;
    //        obj.currency = value.currency;
    //        this.props.actions.AddEditBank(obj);
    //        this.handleClose();
    //        this.props.actions.getAllBank();
    //    } else {
    //        alert("add")
    //        let obj = {};
    //        obj.id = value.id;
    //        obj.name = value.Name;
    //        obj.type = value.type;
    //        obj.currency = value.currency;
    //        this.props.actions.AddEditBank(obj);
    //        this.handleClose();
    //        this.props.actions.getAllBank();
    //    }
    //}





    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left"> الخزينه الرئيسيه</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        {/*<div className="page-title-actions">*/}
                        {/*    */}{/*<Button size="lg" onClick={this.showModal.bind(this)}>إضافة</Button>*/}
                        {/*    {this.state.selected.length > 0 ?*/}
                        {/*        <Button size="lg" onClick={this.showDeleteModal.bind(this)}>حذف</Button>*/}
                        {/*        : null}*/}
                        {/*</div>*/}
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editBank}
                            data={this.props.ListBank}
                            columns={this.cells}
                        />
                    </div>
                </div>
                <Modal show={this.state.show} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        تسجيل سحب او ايداع  
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} onSubmit={(values) => { this.addeditBank(values) }}
                            initialValues={{
                                id: this.state.id,
                                Name: this.state.Name,
                                type: this.state.type,
                                currency: this.state.currency,
 
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, setFieldValue, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="type">
                                        <Form.Label>النوع</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="النوع "
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="type"
                                            autoComplete="off"
                                            value={values.type}

                                            onBlur={handleBlur}
                                            isInvalid={!!errors.type}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.type}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="currency">
                                        <Form.Label>العمله</Form.Label>
                                        <Select
                                            name="currency"
                                            id="currency"
                                            value={values.currency}
                                            onChange={(opt) => {
                                                setFieldValue("currency", opt);
                                            }}
                                            onBlur={handleBlur}
                                            error={errors.storeName}
                                            touched={touched.storeName}
                                        ><option value="DICTUM">Dictamen</option>
                                            </Select>
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.currency}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <div style={{ direction: "ltr" }}>
                                        <Button size="lg" onClick={this.handleClose.bind(this)} style={{ marginRight: '10px' }}>
                                            غلق
                                        </Button>
                                        {this.state.isLoading ? <Button size="lg" disabled  >
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
    ListBank: state.reduces.ListBank
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Bank);