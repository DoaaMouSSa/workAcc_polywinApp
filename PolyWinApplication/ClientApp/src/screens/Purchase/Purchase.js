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
    //productName: Yup.string().required("برجاء إدخال اسم ").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class Purchase extends Component {

    constructor(props) {

        super(props);
        this.handleKeyUpForPieces = this.handleKeyUpForPieces.bind(this);
        this.handleMouseUpForPieces = this.handleMouseUpForPieces.bind(this);
        this.handleKeyUpForFinalPrice = this.handleKeyUpForFinalPrice.bind(this);
        this.handleMouseUpForFinalPrice = this.handleMouseUpForFinalPrice.bind(this);

        let role_id = JSON.parse(localStorage.getItem("role_id"));
        if ((role_id == 2) || (role_id == 3)) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }
        // this is columns of Supplier
        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
            return(
            <div>
                <Form.Check
                    checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
                    onChange={() => this.toggleRow(rowInfo.original.id)} />
                <OverlayTrigger
                        key={`${rowInfo.original.allProducts}`}
                    placement={'top'}
                    overlay={
                        <Tooltip id={`tooltip-top`}>
                            <strong>المنتجات </strong>
                        </Tooltip>
                    }>
                    <Button variant="info" onClick={() =>
                        this.setState({
                            showDetailsInv: true,
                            objProducts: rowInfo.original.allProducts
                        })
                    } className="EditCredit" style={{ cursor: 'pointer' }}>عرض تفاصيل الفاتوره</Button>
                </OverlayTrigger>
            </div>
                    );
                },
    sortable: false,
    width: 250
},
            {
                Header: <strong>م</strong>,
                accessor: 'id',
                width: 50,
                filterable: true,
            },
            {
                Header: <strong>سند الاستلام</strong>,
                accessor: 'inv_Code',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong> المورد</strong>,
                accessor: 'supplier_Name',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong>العميل</strong>,
                accessor: 'client_Name',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong>نوع العمليه</strong>,
                accessor: 'type',
                width: 120,
                filterable: true,
            }
            , {
                Header: <strong> العمله  </strong>,
                accessor: 'currency_Name',
                width: 120,
                filterable: true,
            },{
                Header: <strong>اجمالى </strong>,
                accessor: 'inv_total',
                width: 120,
                filterable: true,
            }
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            id: 0,
            show: false,
            sum: 1,
            showDetailsInv: false,
            objProducts: [],
            objPurchase: {
                Id: 0,
                productName: "",
                nameItemType: "",
                supplierName: "",
                currencyName: "",
                unit_purchase: 1,
                priceForOnePiece: 1,
                numberOfPieces: 1,
                priceOfAllPieces: 1,
                qty: 1,
                totalPrice_purchase:1,        
            },
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListPurchase && nextState.ListPurchase.length > 0) {

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
        this.props.actions.getPurchase();
        this.props.actions.getAllProductForDrop();
        this.props.actions.getAllItemType();
        this.props.actions.getAllItemTypeForDrop();
        this.props.actions.getAllSupplierForDrop();
        this.props.actions.getCurrencyForDrop();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            objPurchase: {
                Id: 0,
                productName: "",
                nameItemType: "",
                supplierName: "",
                currencyName:"",
                unit_purchase: 1,
                priceForOnePiece: 1,
                numberOfPieces: 1,
                priceOfAllPieces: 1,
                qty: 1,
                totalPrice_purchase: 1,
            },
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
            showConfirme: false,
            showDetailsInv: false,
            isLoading: false
        });
    }
    handleKeyUpForFinalPrice() {
        var unitPriceWhole = document.getElementById('unitPriceWhole').value;
        var qty = document.getElementById('qty').value;
        var fianlresult = unitPriceWhole * qty;
        document.getElementById('totalPrice_purchase').value = fianlresult;
        this.setState({
            sum: fianlresult
        })
    } 
    handleMouseUpForFinalPrice() {
        var unitPriceWhole = document.getElementById('unitPriceWhole').value;
        var qty = document.getElementById('qty').value;
        var fianlresult = unitPriceWhole * qty;
        document.getElementById('totalPrice_purchase').value = fianlresult;
        this.setState({
            sum: fianlresult
        })
    }
    handleKeyUpForPieces() {
        var priceForOnePiece = document.getElementById('priceForOnePiece').value;
        var numberOfPieces = document.getElementById('numberOfPieces').value;
        var resultPieces = priceForOnePiece * numberOfPieces;
        document.getElementById('totalPrice_purchase').value = resultPieces;
        document.getElementById('priceOfAllPieces').value = resultPieces;
        document.getElementById('unitPriceWhole').value = resultPieces;
    }
    
    handleMouseUpForPieces(){
        var priceForOnePiece = document.getElementById('priceForOnePiece').value;
        var numberOfPieces = document.getElementById('numberOfPieces').value;
        var resultPieces = priceForOnePiece * numberOfPieces;
        document.getElementById('totalPrice_purchase').value = resultPieces;
        document.getElementById('priceOfAllPieces').value = resultPieces;
        document.getElementById('unitPriceWhole').value = resultPieces;
    }
    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.DeletePurchase(this.state.selected);
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

    editPurchase = (state, rowInfo, column, instance) => {
        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
                    let obj = this.state.objPurchase;

                    obj.productName = { value: rowInfo.original.productId, label: rowInfo.original.productName };
                    obj.nameItemType = { value: rowInfo.original.itemtypeId, label: rowInfo.original.nameItemType };
                    obj.supplierName = { value: rowInfo.original.supplierId, label: rowInfo.original.supplierName }
                    obj.currenyName = { value: rowInfo.original.currencyId, label: rowInfo.original.currencyName }
                    obj.unit_purchase = rowInfo.original.unit_purchase;
                    obj.qty = rowInfo.original.qty;
                    obj.totalPrice_purchase = rowInfo.original.totalPrice_purchase;
                    obj.Id = rowInfo.original.id;
                    this.setState({
                        objPurchase: obj,
                        show: true
                    });

                }
            }
        };
    };
    addeditPurchase = (value) => {
        this.setState({
            isLoading: true
        });
        let obj = {};
        obj.id = value.Id;
        obj.product_id = value.productName.value;
        obj.unit_id = value.nameItemType.value;
        obj.supplier_id = value.supplierName.value;
        obj.unit_purchase = value.unit_purchase;
        obj.currency_id = value.currencyName.value;
        obj.priceForOnePiece = value.priceForOnePiece;
        obj.numberOfPieces = value.qty;
        obj.priceOfAllPieces = value.qty;
        obj.qty = value.qty;
        obj.totalPrice_purchase = this.state.sum;
        this.props.actions.AddEditPurchase(obj);
        this.handleClose();
        this.props.actions.getPurchase();
        }
    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">المشتريات</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            <Button size="lg" onClick={this.showModal.bind(this)}>إضافة</Button>                         
                        </div>
                      
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editPurchase}
                            data={this.props.ListPurchase}
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
                                this.addeditPurchase(values)
                            }}
                            initialValues={{
                                id: this.state.id,
                                productName: this.state.objPurchase.productName,
                                nameItemType: this.state.objPurchase.nameItemType,
                                supplierName: this.state.objPurchase.supplierName,
                                currencyName: this.state.objPurchase.CurrencyName,
                                unit_purchase: this.state.objPurchase.unit_purchase,
                                priceForOnePiece: this.state.objPurchase.priceForOnePiece,
                                numberOfPieces: this.state.objPurchase.numberOfPieces,
                                priceOfAllPieces: this.state.objPurchase.priceOfAllPieces,
                                qty: this.state.objPurchase.qty,
                                totalPrice_purchase: this.state.objPurchase.totalPrice_purchase,               
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Row>
                                        <Col>
                                    <Form.Group controlId="productName">
                                        <Form.Label> المنتج</Form.Label>
                                        <Select
                                            name="productName"
                                            id="productName"
                                            value={values.productName}
                                            onChange={(opt) => {
                                                setFieldValue("productName", opt);
                                            }}
                                            options={this.props.ListProductNameForDrop}
                                            onBlur={handleBlur}
                                            error={errors.productName}
                                            touched={touched.productName}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.productName}
                                        </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                    <Form.Group controlId="nameItemType">
                                        <Form.Label> الوحده</Form.Label>
                                        <Select
                                            name="nameItemType"
                                            id="nameItemType"
                                            value={values.nameItemType}
                                            onChange={(opt) => {
                                                setFieldValue("nameItemType", opt);
                                            }}
                                            options={this.props.ListItemTypeForDrop}
                                            onBlur={handleBlur}
                                            error={errors.nameItemType}
                                            touched={touched.nameItemType}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                            {errors.nameItemType}
                                        </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="supplierName">
                                                <Form.Label>المورد </Form.Label>
                                                <Select
                                                    name="supplierName"
                                                    id="supplierName"
                                                    value={values.supplierName}
                                                    onChange={(opt) => {
                                                        setFieldValue("supplierName", opt);
                                                    }}
                                                    options={this.props.ListSupplierForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.supplierName}
                                                    touched={touched.supplierName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.supplierName}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="currencyName">
                                                <Form.Label> العمله</Form.Label>
                                                <Select
                                                    name="currencyName"
                                                    id="currencyName"
                                                    value={values.currencyName}
                                                    onChange={(opt) => {
                                                        setFieldValue("currencyName", opt);
                                                    }}
                                                    options={this.props.ListCurrencyForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.currencyName}
                                                    touched={touched.currencyName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.currencyName}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="priceForOnePiece">
                                                <Form.Label>سعر القطعه</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=""
                                                    onChange={handleChange}
                                                    onKeyUp={this.handleKeyUpForPieces}
                                                    onMouseUp={this.handleMouseUpForPieces}
                                                    type="number"
                                                    aria-describedby="inputGroupPrepend"
                                                    name="priceForOnePiece"
                                                    autoComplete="off"
                                                    min="1"
                                                    value={values.priceForOnePiece}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.priceForOnePiece}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.priceForOnePiece}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="numberOfPieces">
                                                <Form.Label> عدد القطع</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=""
                                                    onChange={handleChange}
                                                    onKeyUp={this.handleKeyUpForPieces}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="numberOfPieces"
                                                    onMouseUp={this.handleMouseUpForPieces}
                                                    type="number"
                                                    autoComplete="off"
                                                    min="1"
                                                    value={values.numberOfPieces}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.numberOfPieces}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.numberOfPieces}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="priceOfAllPieces">
                                                <Form.Label> اجمالى القطع</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=""
                                                    aria-describedby="inputGroupPrepend"
                                                    name="priceOfAllPieces"
                                                    autoComplete="off"
                                                    value={this.priceOfAllPieces}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.priceOfAllPieces}
                                                    readOnly
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.priceOfAllPieces}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                    </Row>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="unitPriceWhole">
                                                <Form.Label> سعر الوحده </Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=""
                                                    aria-describedby="inputGroupPrepend"
                                                    name="unitPriceWhole"
                                                    autoComplete="off"
                                                    value={this.unitPriceWhole}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.unitPriceWhole}
                                                    readOnly
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.unitPriceWhole}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="qty">
                                                <Form.Label> عدد الوحدات</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=""
                                                    onChange={handleChange}
                                                    onKeyUp={this.handleKeyUpForFinalPrice}
                                                    onMouseUp={this.handleMouseUpForFinalPrice}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="qty"
                                                    type="number"
                                                    autoComplete="off"
                                                    min="1"
                                                    value={values.qty}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.qty}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.qty}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Group controlId="totalPrice_purchase">
                                                <Form.Label>القيمه النهائيه</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=""
                                                    aria-describedby="inputGroupPrepend"
                                                    name="totalPrice_purchase"
                                                    autoComplete="off"
                                                    value={this.totalPrice_purchase}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.totalPrice_purchase}
                                                    readOnly
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.totalPrice_purchase}
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
                <Modal show={this.state.showDetailsInv} onHide={this.handleClose.bind(this)}>
                    <Modal.Body className="modal-header">
                        {this.state.objProducts.map((data, idx) => (
                            <p key={idx}>{data.productName}</p>
                        ))}
                    </Modal.Body>
                </Modal>
                {this.state.showConfirme ? <Confirme text="هل تريد الحذف ?" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
            </div>
        );
    }
}

const mapStateToProps = (state, ownProps) => ({
    ListProductNameForDrop: state.reduces.ListProductNameForDrop,
    ListPurchase: state.reduces.ListPurchase,
    ListItemTypeForDrop: state.reduces.ListItemTypeForDrop,
    ListSupplierForDrop: state.reduces.ListSupplierForDrop,
    ListCurrencyForDrop: state.reduces.ListCurrencyForDrop
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Purchase);