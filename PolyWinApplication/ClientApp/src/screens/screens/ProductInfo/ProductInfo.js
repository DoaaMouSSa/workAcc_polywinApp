import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, Row, Col, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import Select from "react-select";
import '../../Design/CSS/custom.css';

// validation of field
const schema = Yup.object({
    productCode: Yup.string().required("برجاء إدخال كود الصنف"),
    //pricePerOne: Yup.string().required("برجاء إدخال كود الصنف"),
    // CategoryTypeName: Yup.string().required("برجاء الأختيار نوع الملف"),
});


class ProductInfo extends Component {

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
                width: 30
            },
            {
                Header: <strong> القسم </strong>,
                accessor: 'categoryName',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong> كود المنتج </strong>,
                accessor: 'productCode',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong> اسم المنتج </strong>,
                accessor: 'name',
                width: 220,
                filterable: true,
            }, {
                Header: <strong> اللون </strong>,
                accessor: 'colorName',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong> السعر بالوحدة </strong>,
                accessor: 'pricePerOne',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong> السعر بالمتر </strong>,
                accessor: 'pricePerMeter',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong> وحدة القياس </strong>,
                accessor: 'measruingUnit',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong> اجمالى الوحدة </strong>,
                accessor: 'totalQuota',
                width: 120,
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
            objProduct: {
                Id: 0,
                categoryName: "",
                productCode: "",
                name: "",
                colorName: "",
                pricePerOne: 0,
                pricePerMeter: 0,
                measruingUnit: "",
                totalQuota: 1
            },
            listTypeOfProduct: [
                { label: "الكرتونه", value: "الكرتونه" },
                { label: "العدد", value: "العدد" },
                { label: "الوزن", value: "الوزن" },
                { label: "الطول", value: "الطول" },
                { label: "اللفة", value: "اللفة" }],
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.listProducts && nextState.listProducts.length > 0) {
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
        this.props.actions.getAllProductForDrop();
        this.props.actions.getAllColorForDrop();
        this.props.actions.getAllCategoryForDrop(); 
        this.props.actions.getAllProductInfo();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            objProduct: {
                Id: 0,
                categoryName: "",
                productCode: "",
                name: "",
                colorName: "",
                pricePerOne: 0,
                pricePerMeter: 0,
                measruingUnit: "",
                totalQuota: 1
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

        this.props.actions.deleteProductInfo(this.state.selected);
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
                    let obj = this.state.objProduct;

                    obj.name = { value: rowInfo.original.productId, label: rowInfo.original.name };
                    obj.categoryName = { value: rowInfo.original.categoryId, label: rowInfo.original.categoryName };
                    obj.colorName = { value: rowInfo.original.colorId, label: rowInfo.original.colorName };
                    obj.measruingUnit = { value: rowInfo.original.measruingUnit, label: rowInfo.original.measruingUnit };
                    obj.productCode = rowInfo.original.productCode;
                    obj.pricePerOne = rowInfo.original.pricePerOne;
                    obj.pricePerMeter = rowInfo.original.pricePerMeter;
                    obj.totalQuota = rowInfo.original.totalQuota;
                    obj.Id = rowInfo.original.id;

                    this.setState({
                        objCategoryGallery: obj,
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
        obj.ProductCode = value.productCode;
        obj.CategoryId = value.categoryName.value;
        obj.PricePerOne = value.pricePerOne;
        obj.TotalQuota = value.totalQuota;
        obj.MeasruingUnit = value.measruingUnit.value;
        obj.PricePerMeter = value.pricePerMeter;
        obj.ProductId = value.name.value;
        obj.ColorId = value.colorName.value;


        this.props.actions.addeditProductInfo(obj);
    }

    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">بيانات المنتجات</h1>
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
                            data={this.props.listProducts}
                            columns={this.cells}
                        />
                    </div>
                </div>
                <Modal show={this.state.show} onHide={this.handleClose.bind(this)} size="lg"
                    aria-labelledby="contained-modal-title-vcenter"
                    centered>
                    <Modal.Header closeButton>
                        إضافة أو تعديل
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} enableReinitialize={true}
                            onSubmit={(values) => {
                                this.addEditCategoryGallery(values)
                            }}
                            initialValues={{
                                Id: this.state.objProduct.Id,
                                productCode: this.state.objProduct.productCode,
                                name: this.state.objProduct.name,
                                categoryName: this.state.objProduct.categoryName,
                                colorName: this.state.objProduct.colorName,
                                pricePerOne: this.state.objProduct.pricePerOne,
                                pricePerMeter: this.state.objProduct.pricePerMeter,
                                measruingUnit: this.state.objProduct.measruingUnit,
                                totalQuota: this.state.objProduct.totalQuota,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="categoryName">
                                                <Form.Label>القسم</Form.Label>
                                                <Select
                                                    name="categoryName"
                                                    id="categoryName"
                                                    value={values.categoryName}
                                                    onChange={(opt) => {
                                                        setFieldValue("categoryName", opt);
                                                    }}
                                                    options={this.props.ListProductCategoryForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.categoryName}
                                                    touched={touched.categoryName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.categoryName}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="name">
                                                <Form.Label>اسم المنتج</Form.Label>
                                                <Select
                                                    name="name"
                                                    id="name"
                                                    value={values.name}
                                                    onChange={(opt) => {
                                                        setFieldValue("name", opt);
                                                    }}
                                                    options={this.props.ListProductNameForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.name}
                                                    touched={touched.name}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.name}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>

                                    <Row>
                                        <Col>
                                            <Form.Group controlId="colorName">
                                                <Form.Label>اللون</Form.Label>
                                                <Select
                                                    name="colorName"
                                                    id="colorName"
                                                    value={values.colorName}
                                                    onChange={(opt) => {
                                                        setFieldValue("colorName", opt);
                                                    }}
                                                    options={this.props.ListProductColorForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.colorName}
                                                    touched={touched.colorName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.colorName}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="productCode">
                                                <Form.Label>كود الصنف</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "50px" }}
                                                    placeholder="الوصف"
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="productCode"
                                                    autoComplete="off"
                                                    value={values.productCode}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.productCode}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.productCode}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>

                                    <Row>
                                        <Col>
                                            <Form.Group controlId="totalQuota">
                                                <Form.Label>اجمالى الوحدة</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "50px" }}
                                                    placeholder="الوصف"
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="totalQuota"
                                                    type="number"
                                                    autoComplete="off"
                                                    value={values.totalQuota}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.totalQuota}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.totalQuota}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="pricePerOne">
                                                <Form.Label>السعر بالوحدة</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "50px" }}
                                                    placeholder="الوصف"
                                                    type="number"
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="pricePerOne"
                                                    autoComplete="off"
                                                    value={values.pricePerOne}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.pricePerOne}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.pricePerOne}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>

                                    <Row>
                                        <Col>
                                            <Form.Group controlId="pricePerMeter">
                                                <Form.Label>السعر بالمتر</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "50px" }}
                                                    placeholder="الوصف"
                                                    type="number"
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="pricePerMeter"
                                                    autoComplete="off"
                                                    value={values.pricePerMeter}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.pricePerMeter}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.pricePerMeter}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="measruingUnit">
                                                <Form.Label>نوع الوحدة</Form.Label>
                                                <Select
                                                    name="measruingUnit"
                                                    id="measruingUnit"
                                                    value={values.measruingUnit}
                                                    onChange={(opt) => {
                                                        setFieldValue("measruingUnit", opt);
                                                    }}
                                                    options={this.state.listTypeOfProduct}
                                                    onBlur={handleBlur}
                                                    error={errors.measruingUnit}
                                                    touched={touched.measruingUnit}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.measruingUnit}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>
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
    ListProductNameForDrop: state.reduces.ListProductNameForDrop,
    ListProductColorForDrop: state.reduces.ListProductColorForDrop,
    ListProductCategoryForDrop: state.reduces.ListProductCategoryForDrop,
    listProducts: state.reduces.listProducts
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(ProductInfo);