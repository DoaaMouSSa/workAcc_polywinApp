import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, Alert, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import Select from "react-select";
import axiosDocsControlle from '../../axios/axiosControlle';
import '../../Design/CSS/custom.css';

// validation of field
const schema = Yup.object({
    equation: Yup.string().required("برجاء إدخال المعادلة"),
    // categoryGalleryName: Yup.string().required("برجاء الأختيار نوع الملف"),
});


const equetionSchema = Yup.object({
    Height: Yup.string().required("برجاء إدخال العرض"),
    Width: Yup.string().required("برجاء إدخال الطول")
});

class ProductIngredient extends Component {

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
                Header: <strong> المنتج </strong>,
                accessor: 'productName',
                width: 220,
                filterable: true,
            },
            {
                Header: <strong> المعادلة</strong>,
                accessor: 'equation',
                width: 220,
                filterable: true,
                Cell: props => <span style={{ direction: "ltr" }}>{props.value}</span>
            },
            {
                Header: "",
                id: "CheckEquation",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <div>
                            <OverlayTrigger
                                key={`topupdate-${rowInfo.original.id}`}
                                placement={'top'}
                                overlay={
                                    <Tooltip id={`tooltip-top`}>
                                        <strong>تعديل</strong>.
                             </Tooltip>
                                }>
                                <Button variant="danger" className="EditCredit" style={{ cursor: 'pointer' }}>حساب المعادلة</Button>
                            </OverlayTrigger>
                        </div>
                    );
                },
                sortable: false,
                width: 200
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
            showEquetion: false,
            objIngredient: {
                Id: 0,
                equation: "",
                productId: "",
                subCategoryId: "",
            },
            ListProductIngredient: [],
            objEquestion: {
                Height: "",
                Width: "",
                ProductId: ""
            },
            totalEqution: 0
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListProductIngredient && nextState.ListProductIngredient.length > 0) {
            if (this.state.objIngredient.subCategoryId != "") {
                let ListProduct = nextState.ListProductIngredient.filter(x => x.subCategoryId == this.state.objIngredient.subCategoryId);

                this.setState({
                    isLoading: false,
                    show: false,
                    showEquetion:false,
                    ListProductIngredient: ListProduct
                });
            } else {
                let obj = this.state.objIngredient;
                obj["subCategoryId"] = "";

                this.setState({
                    objIngredient: obj,
                    isLoading: false,
                    show: false,
                    showEquetion: false,
                    customerId: '',
                    ListProductIngredient: []
                });
            }
        } else {
            this.setState({
                isLoading: false,
                show: false,
                showEquetion: false,
                ListProductIngredient: []
            });
        }
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.getAllSubCategoryForDropDown();
        this.props.actions.getAllProductWithColor();
        this.props.actions.getAllProductIngreditent();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            objIngredient: {
                Id: 0,
                equation: "",
                productId: "",
                subCategoryId: this.state.objIngredient.subCategoryId.value,
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
            showConfirme: false,
            showEquetion: false,
        });
    }

    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.deleteProductIngredient(this.state.selected);
    }

    // this function when leave from page
    componentWillUnmont() {
        this.setState({
            show: false,
            isLoading: false,
            showConfirme: false,
            showEquetion: false,
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
                    let obj = this.state.objIngredient;

                    obj.productId = { value: rowInfo.original.productId, label: rowInfo.original.productName };
                    obj.equation = rowInfo.original.equation;
                    obj.Id = rowInfo.original.id;

                    this.setState({
                        objIngredient: obj,
                        show: true
                    });
                } 
                if (e.target.type === "button") {
                    let obj = this.state.objEquestion;

                    obj["ProductId"] = rowInfo.original.productId;

                    this.setState({
                        totalEqution: 0,
                        objEquestion: obj,
                        showEquetion: true
                    });
                }
            }
        };
    };

    addEditProductIngredient = (value) => {
        this.setState({
            isLoading: true
        });

        let obj = {};
        obj.id = value.Id;
        obj.equation = value.equation;
        obj.SubCategoryId = this.state.objIngredient.subCategoryId;
        obj.ProductId = value.productId.value;

        this.props.actions.addEditProductIngredient(obj);
    }

    handleDropDown = (event) => {
        let obj = this.state.objIngredient;
        let objRow = this.props.ListProductIngredient.filter(x => x.subCategoryId == event.value);

        obj["subCategoryId"] = event;

        this.setState({
            objIngredient: obj,
            ListProductIngredient: objRow
        });
    }


    getCalcProduct =(value) => {

        let productId = this.state.objEquestion.ProductId;
        let Width = value.Width;
        let Height = value.Height ;

        axiosDocsControlle.get(`GetCalcProduct?productId=${productId}&width=${Width}&height=${Height}`).then(res => {
            this.setState({
                totalEqution: res.data
            });
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
                                    <h1 className="main-title float-left">مكونات المنتج جزء القطاعات</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <Form.Group controlId="subCategoryId">
                            <Form.Label>المنتج</Form.Label>
                            <Select
                                name="subCategoryId"
                                id="subCategoryId"
                                value={this.state.objIngredient.subCategoryId}
                                onChange={(opt) => {
                                    /*  setFieldValue("productId", opt);*/
                                    this.handleDropDown(opt);
                                }}
                                options={this.props.ListSubCategoryForDrop}
                            />
                        </Form.Group>
                        <br />
                        {this.state.objIngredient.subCategoryId != "" ? <div className="page-title-actions">
                            <Button size="lg" onClick={this.showModal.bind(this)}>إضافة</Button>
                            {this.state.selected.length > 0 ?
                                <Button size="lg" onClick={this.showDeleteModal.bind(this)}>حذف</Button>
                                : null}
                        </div> : null}
                        <br />

                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editCategoryGallery}
                            data={this.state.ListProductIngredient}
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
                                this.addEditProductIngredient(values)
                            }}
                            initialValues={{
                                Id: this.state.objIngredient.Id,
                                productId: this.state.objIngredient.productId,
                                equation: this.state.objIngredient.equation,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="productId">
                                        <Form.Label>القطع</Form.Label>
                                        <Select
                                            name="productId"
                                            id="productId"
                                            value={values.productId}
                                            onChange={(opt) => {
                                                setFieldValue("productId", opt);
                                            }}
                                            options={this.props.ListProductForDrop}
                                            onBlur={handleBlur}
                                            error={errors.productId}
                                            touched={touched.productId}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.productId}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="equation">
                                        <Form.Label>المعادلة</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px", direction: "ltr" }}
                                            placeholder="المعادلة"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="equation"
                                            autoComplete="off"
                                            value={values.equation}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.equation}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.equation}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Alert key={1} variant={"danger"}>
                                        برجاء كتابة المعادلة بشكل صحيح وتعويض مكان الطول (H) ومكان العرض (W)  مثال  ((W+0.1)*2)+((H+0.1)*2)
                                    </Alert>
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

                <Modal show={this.state.showEquetion} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        حساب المعادلة
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={equetionSchema} enableReinitialize={true}
                            onSubmit={(values) => {
                                this.getCalcProduct(values)
                            }}
                            initialValues={{
                                ProductId: this.state.objEquestion.ProductId,
                                Width: this.state.objEquestion.Width,
                                Height: this.state.objIngredient.Height,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="Height">
                                        <Form.Label>العرض</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="العرض"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="Height"
                                            autoComplete="off"
                                            value={values.Height}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.Height}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.Height}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="Width">
                                        <Form.Label>الطول</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="الطول"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="Width"
                                            autoComplete="off"
                                            value={values.Width}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.Width}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.Width}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Alert key={1} variant={"success"}>
                                        المطلوب : {this.state.totalEqution + "  "}  مترا
                                    </Alert>

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
    ListProductIngredient: state.reduces.ListProductIngredient,
    ListSubCategoryForDrop: state.reduces.ListSubCategoryForDrop,
    ListProductForDrop: state.reduces.ListProductForDrop
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(ProductIngredient);