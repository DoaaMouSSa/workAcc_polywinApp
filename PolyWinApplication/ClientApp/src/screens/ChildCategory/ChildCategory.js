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
import UploadFiles from "../../components/FileUpload/UploadFiles";
import '../../Design/CSS/custom.css';

// validation of field
const schema = Yup.object({
    name: Yup.string().required("برجاء إدخال القسم"),
    // CategoryTypeName: Yup.string().required("برجاء الأختيار نوع الملف"),
});


class ChildCategory extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(sessionStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
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
                            <OverlayTrigger
                                key={`topupdate-${rowInfo.original.id}`}
                                placement={'top'}
                                overlay={
                                    <Tooltip id={`tooltip-top`}>
                                        <strong>الصورة</strong>
                                    </Tooltip>
                                }>
                                <Button variant="danger" onClick={() =>
                                    this.setState({
                                        showImage: true,
                                        ImagePath: rowInfo.original.filePath
                                    })
                                } className="EditCredit" style={{ cursor: 'pointer' }}>عرض الصورة</Button>
                            </OverlayTrigger>
                        </div>
                    );
                },
                sortable: false,
                width: 250
            },
            {
                Header: <strong> نوع المنتج </strong>,
                accessor: 'parentCategoryName',
                width: 220,
                filterable: true,
            },
            {
                Header: <strong> قسم المنتج </strong>,
                accessor: 'name',
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
            objSubCategory: {
                Id: 0,
                name: "",
                ParentCategoryId: ""
            },
            file: "",
            showImage: false
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListSubCategory && nextState.ListSubCategory.length > 0) {
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
        this.props.actions.getAllSubCategory();
        this.props.actions.getAllParentCategoryForDrop();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            file: "",
            objSubCategory: {
                Id: 0,
                name: "",
                ParentCategoryId: ""
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

        this.props.actions.deleteSubCategory(this.state.selected);
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
                    let obj = this.state.objSubCategory;

                    obj.ParentCategoryId = { value: rowInfo.original.parentCategoryId, label: rowInfo.original.parentCategoryName };
                    obj.name = rowInfo.original.name;
                    obj.Id = rowInfo.original.id;

                    this.setState({
                        objCategoryGallery: obj,
                        show: true,
                        file: "",
                    });
                }
            }
        };
    };

    addEditCategoryGallery = (value) => {
        this.setState({
            isLoading: true
        });
          
        if (value.Id > 0) {
            const body = new FormData();

            body.append('fileUpload', this.state.file);
            body.append('ParentCategoryId', value.ParentCategoryId.value);
            body.append('name', value.name);
            body.append('Id', value.Id);

            this.props.actions.addeditSubCategory(body);
        }
        else {
            if (this.state.file !== "") {
                const body = new FormData();

                body.append('fileUpload', this.state.file);
                body.append('ParentCategoryId', value.ParentCategoryId.value);
                body.append('name', value.name);
                body.append('Id', value.Id);

                this.props.actions.addeditSubCategory(body);
            } else {
                toastr.success("برجاء اختيار الصورة");
                this.setState({
                    isLoading: false
                });
            }
        }
    }

    getfileInfo = (files) => {
        this.setState({
            file: files
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
                                    <h1 className="main-title float-left">الاقسام الفرعية للمنتجات</h1>
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
                            data={this.props.ListSubCategory}
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
                                Id: this.state.objSubCategory.Id,
                                name: this.state.objSubCategory.name,
                                ParentCategoryId: this.state.objSubCategory.ParentCategoryId,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="ParentCategoryId">
                                        <Form.Label>القسم الرئيسى</Form.Label>
                                        <Select
                                            name="ParentCategoryId"
                                            id="ParentCategoryId"
                                            value={values.ParentCategoryId}
                                            onChange={(opt) => {
                                                setFieldValue("ParentCategoryId", opt);
                                            }}
                                            options={this.props.ListParentCategoryForDrop}
                                            onBlur={handleBlur}
                                            error={errors.ParentCategoryId}
                                            touched={touched.ParentCategoryId}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.ParentCategoryId}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="name">
                                        <Form.Label>الوصف</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="الوصف"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="name"
                                            autoComplete="off"
                                            value={values.name}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.name}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.name}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <UploadFiles acceptFile="image/*" getfileInfo={this.getfileInfo} />

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

                <Modal show={this.state.showImage} onHide={this.handleClose.bind(this)}>
                    <Modal.Body className="modal-header">
                        {this.state.ImagePath !== "" || this.state.ImagePath !== null ?
                            <img src={this.state.ImagePath} style={{ width: '100%' }} />
                            : <div>
                                <span>
                                    لا توجد صورة
                            </span>
                            </div>
                        }
                    </Modal.Body>
                </Modal>

                {this.state.showConfirme ? <Confirme text="هل تريد الحذف ?" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListParentCategoryForDrop: state.reduces.ListParentCategoryForDrop,
    ListSubCategory: state.reduces.ListSubCategory
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(ChildCategory);