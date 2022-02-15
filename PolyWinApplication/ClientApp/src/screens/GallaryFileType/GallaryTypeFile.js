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
import UploadFiles from "../../components/FileUpload/UploadFiles";
import Select from "react-select";
import '../../Design/CSS/custom.css';


// validation of field
const schema = Yup.object({
    description: Yup.string().required("برجاء إدخال الوصف ").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class GallaryTypeFile extends Component {

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
                                        <strong>الملف</strong>
                                    </Tooltip>
                                }>
                                <a variant="danger" href={rowInfo.original.filePath} target="_blank">عرض الملف</a>
                            </OverlayTrigger>
                        </div>
                    );
                },
                sortable: false,
                width: 150
            },
            {
                Header: <strong> القسم </strong>,
                accessor: 'categoryName',
                width: 220,
                filterable: true,
            },
            {
                Header: <strong> الوصف </strong>,
                accessor: 'description',
                width: 220,
                filterable: true,
            }
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            description: "",
            id: 0,
            ImagePath: "",
            show: false,
            showImage: false,
            objGallery: {
                Id: 0,
                description: "",
                categoryId: ""
            }
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.listGallery && nextState.listGallery.length > 0) {

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
        this.props.actions.getAllGalleryByType(2);
        this.props.actions.getAllCategoryChildGalleryForDrop();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            description: "",
            ImagePath: "",
            file: "",
            id: 0
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

        this.props.actions.deleteGallery(this.state.selected);
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

    editGallary = (state, rowInfo, column, instance) => {

        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {

                    let obj = this.state.objGallery;

                    obj.categoryId = { value: rowInfo.original.categoryId, label: rowInfo.original.categoryName };
                    obj.description = rowInfo.original.description;
                    obj.Id = rowInfo.original.id;

                    this.setState({
                        objGallery: obj,
                        file: "",
                        show: true
                    });
                }
            }
        };
    };

    getfileInfo = (files) => {
        this.setState({
            file: files
        });
    }

    addEditGallery = (value) => {

        this.setState({
            isLoading: true
        });

        if (value.id > 0) {
            const body = new FormData();

            body.append('fileUpload', this.state.file);
            body.append('Description', value.description);
            body.append('CategoryId', value.categoryId.value);
            body.append('typeGallery', 2);
            body.append('Id', value.id);

            this.props.actions.addeditGallery(body);
        } else {
            if (this.state.file !== "") {
                const body = new FormData();

                body.append('fileUpload', this.state.file);
                body.append('Description', value.description);
                body.append('CategoryId', value.categoryId.value);
                body.append('typeGallery', 2);
                body.append('Id', value.id);

                this.props.actions.addeditGallery(body);
            } else {
                toastr.success("برجاء اختيار الملف");
                this.setState({
                    isLoading: false
                });
            }
        }
    }

    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">تسجيل بيانات المعرض من نوع ملفات</h1>
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
                            getTrProps={this.editGallary}
                            data={this.props.listGallery}
                            columns={this.cells}
                        />
                    </div>
                </div>

                <Modal show={this.state.show} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        إضافة أو تعديل
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} onSubmit={(values) => { this.addEditGallery(values) }}
                            initialValues={{
                                id: this.state.objGallery.Id,
                                description: this.state.objGallery.description,
                                categoryId: this.state.objGallery.categoryId
                            }}>
                            {({ handleSubmit, handleChange, setFieldValue, handleBlur, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="categoryId">
                                        <Form.Label>القسم الفرعى</Form.Label>
                                        <Select
                                            name="categoryId"
                                            id="categoryId"
                                            value={values.categoryId}
                                            onChange={(opt) => {
                                                setFieldValue("categoryId", opt);
                                            }}
                                            options={this.props.listCategoryChildGalleryForDrop}
                                            onBlur={handleBlur}
                                            error={errors.categoryId}
                                            touched={touched.categoryId}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.categoryId}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="description">
                                        <Form.Label>الوصف</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="الوصف"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="description"
                                            autoComplete="off"
                                            value={values.description}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.description}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.description}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <UploadFiles acceptFile="application/pdf" getfileInfo={this.getfileInfo} />

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
    listCategoryChildGalleryForDrop: state.reduces.listCategoryChildGalleryForDrop,
    listGallery: state.reduces.listGallery
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(GallaryTypeFile);