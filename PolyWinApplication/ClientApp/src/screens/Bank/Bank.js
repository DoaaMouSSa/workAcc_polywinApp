import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, OverlayTrigger, Tooltip, Row, Col } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import Select from "react-select";
import '../../Design/CSS/custom.css';
import UploadFiles from "../../components/FileUpload/UploadFiles";

// validation of field
const schema = Yup.object({
    Name: Yup.string().required("برجاء إدخال اسم الخزينه").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class Bank extends Component {

    constructor(props) {

        super(props);

        let role_id = JSON.parse(localStorage.getItem("role_id"));

        if (role_id == 3 || role_id == 1 || role_id == 2 || role_id == 4) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }

        // this is columns of Bank
        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <div>
                            <OverlayTrigger
                                key={`topimg-${rowInfo.original.id}`}
                                placement={'top'}
                                overlay={
                                    <Tooltip id={`tooltip-top`}>
                                        <strong>الصورة</strong>
                                    </Tooltip>
                                }>
                                <Button variant="info" onClick={() =>
                                    this.setState({
                                        showImage: true,
                                        ImagePath: rowInfo.original.logoPath
                                    })
                                } className="EditCredit" style={{ cursor: 'pointer' }}>عرض الصورة</Button>
                            </OverlayTrigger>
                        </div>
                    );
                },
                sortable: false,
                width: 120
            },
            {
                Header: <strong> اسم الحساب </strong>,
                accessor: 'name',
                width: 100,
                filterable: true,
            },
            
            {
                Header: <strong>الرصيد</strong>,
                accessor: 'balance',
                width: 100,
                filterable: true,
            },
           {
                Header: <strong>الوارد</strong>,
                accessor: 'in',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong>القيمه المدفوعه</strong>,
                accessor: 'out',
                width: 100,
                filterable: true,
            }, {
                Header: <strong>التاريخ</strong>,
                accessor: 'date',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong>نوع العمليه</strong>,
                accessor: 'orderType',
                width: 100,
                filterable: true,
            }, {
                Header: <strong>الموظف</strong>,
                accessor: 'emp_name',
                width: 100,
                filterable: true,
            }, {
                Header: <strong>البنك</strong>,
                accessor: 'bank_name',
                width: 100,
                filterable: true,
            }, {
                Header: <strong>العمله</strong>,
                accessor: 'currency_name',
                width: 100,
                filterable: true,
            }, {
                Header: <strong>طريقه الدفع</strong>,
                accessor: 'payment_name',
                width: 100,
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
            showImage: false,
            ImagePath: "",
            objEda3:{
            currencyName: "",
                bankName: "",
                paymentName: "",
                emp_name: "",
                money: 0,
            },
            
            objSa7b: {
                currencyName: "",
                bankName: "",
                paymentName: "",
                emp_name: "",
                money: 0,
                emp_name: "",
            }
      
          
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListBank && nextState.ListBank.length > 0) {

            this.setState({
                isLoading: false,
                show: false,
                showSa7b:false
            });
        } else {
            this.setState({
                isLoading: false,
                show: false,
                showSa7b: false
            });
        }
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.getAllBank();
        this.props.actions.getCurrencyForDrop();
        this.props.actions.getBankOutForDrop();
        this.props.actions.getPaymentForDrop();

    }

    // this function when add new data and view modal
showModalEda3() {
    this.setState({
        show: true,
        Id: 0,
        Name: "",
        type: "",
        logo: "",
        ImagePath: "",
        objEda3: {
            currencyName: "",
            bankName: "",
            paymentName: "",
            emp_name: "",
            money: 0,
        }
    })
}
    showModalSa7b() {
        this.setState({
            showSa7b: true,
            Id: 0,
            Name: "",
            type: "",
            logo: "",
            ImagePath: "",
            objSa7b: {
                currencyName: "",
                bankName: "",
                paymentName: "",
                emp_name: "",
                money: 0,
            }
        });
    }
    //showDeleteModal() {
    //    this.setState({
    //        showConfirme: true
    //    });
    //}
    getfileInfo = (files) => {
        this.setState({
            file: files
        });
    }

    getImgInfo = (files) => {
        this.setState({
            logo: files
        });
    }

    // this function when close modal
    handleClose() {
        this.setState({
            show: false,
            showConfirme: false,
            showSa7b:false,
            isLoading: false,
            showImage: false,
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
            showSa7b:false,
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
    addDeposit = (value) => {
        this.setState({
            isLoading: true
        });
        const body = new FormData();
        body.append('id', value.id);
        body.append('balance', value.money);
        body.append('logo', this.state.logo);
        body.append('currency_id', value.currencyName.value);
        body.append('bank_id', value.bankName.value);
        body.append('payment_id', value.paymentName.value);
        body.append('emp_name', value.emp_name);
        this.props.actions.addDeposit(body);
            this.handleClose();
            this.props.actions.getAllBank();
        }
    decreaseDeposit = (value) => {
        this.setState({
            isLoading: true
        });
        const body = new FormData();
        body.append('id', value.id);
        body.append('balance', value.money);
        body.append('logo', this.state.logo);
        body.append('currency_id', value.currencyName.value);
        body.append('bank_id', value.bankName.value);
        body.append('payment_id', value.paymentName.value);
        body.append('emp_name', value.emp_name);
        this.props.actions.decreasedeposit(body);
        this.handleClose();
        this.props.actions.getAllBank(); 

    }
    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">الخزينه الرئيسيه</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            <Button size="lg" onClick={this.showModalEda3.bind(this)}>ايداع</Button>
                            <Button size="lg" variant="danger" onClick={this.showModalSa7b.bind(this)}>سحب</Button>
                        </div>
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
                       ايداع - المعاملات البنكيه
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik enableReinitialize={true}
                            onSubmit={(values) => { this.addDeposit(values) }}
                            initialValues={{
                                id: this.state.id,
                                Name: this.state.Name,
                                type: this.state.type,
                                currencyName: this.state.objEda3.CurrencyName,
                                bankName: this.state.objEda3.bankName,
                                paymentName: this.state.objEda3.paymentName,
                                money: this.state.objEda3.money,
                                emp_name: this.state.objEda3.emp_name
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, setFieldValue, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Row>
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
                                        <Col>
                                            <Form.Group controlId="bankName">
                                                <Form.Label> البنك</Form.Label>
                                                <Select
                                                    name="bankName"
                                                    id="bankName"
                                                    value={values.bankName}
                                                    onChange={(opt) => {
                                                        setFieldValue("bankName", opt);
                                                    }}
                                                    options={this.props.ListBankOutForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.bankName}
                                                    touched={touched.bankName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.bankName}
                                                </Form.Control.Feedback>
                                            </Form.Group>

                                        </Col>
                                        </Row>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="paymentName">
                                                <Form.Label>طريقه الدفع</Form.Label>
                                                <Select
                                                    name="paymentName"
                                                    id="paymentName"
                                                    value={values.paymentName}
                                                    onChange={(opt) => {
                                                        setFieldValue("paymentName", opt);
                                                    }}
                                                    options={this.props.ListPaymentForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.paymentName}
                                                    touched={touched.paymentName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.paymentName}
                                                </Form.Control.Feedback>
                                            </Form.Group>

                                        </Col>
                                        <Col>
                                            <Form.Group controlId="money">
                                                <Form.Label> المبلغ</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder="المبلغ "
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="money"
                                                    type="number"
                                                    autoComplete="off"
                                                    value={values.money}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.money}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.money}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>

                                    </Row>
                                    <Row>
                                            <Col>
                                                <Form.Group controlId="emp_name">
                                                    <Form.Label> اسم الموظف</Form.Label>
                                                    <Form.Control type="text"
                                                        style={{ height: "30px" }}
                                                    placeholder=" "


                                                        onChange={handleChange}
                                                        aria-describedby="inputGroupPrepend"
                                                    name="emp_name"
                                                        autoComplete="off"
                                                    value={values.emp_name}
                                                        onBlur={handleBlur}
                                                    isInvalid={!!errors.emp_name}
                                                    />
                                                    <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.emp_name}
                                                    </Form.Control.Feedback>
                                                </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Label>صوره الايصال</Form.Label>
                                            <UploadFiles acceptFile="image/*" getfileInfo={this.getImgInfo} />
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
                <Modal show={this.state.showSa7b} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        سحب - المعاملات البنكيه
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik enableReinitialize={true}
                            onSubmit={(values) => { this.decreaseDeposit(values) }}
                            initialValues={{
                                id: this.state.id,
                                Name: this.state.Name,
                                type: this.state.type,
                                currencyName: this.state.objSa7b.CurrencyName,
                                bankName: this.state.objSa7b.bankName,
                                paymentName: this.state.objSa7b.paymentName,
                                money: this.state.objSa7b.money,
                                emp_name: this.state.objSa7b.emp_name
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, setFieldValue, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Row>
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
                                        <Col>
                                            <Form.Group controlId="bankName">
                                                <Form.Label> البنك</Form.Label>
                                                <Select
                                                    name="bankName"
                                                    id="bankName"
                                                    value={values.bankName}
                                                    onChange={(opt) => {
                                                        setFieldValue("bankName", opt);
                                                    }}
                                                    options={this.props.ListBankOutForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.bankName}
                                                    touched={touched.bankName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.bankName}
                                                </Form.Control.Feedback>
                                            </Form.Group>

                                        </Col>
                                    </Row>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="paymentName">
                                                <Form.Label>طريقه الدفع</Form.Label>
                                                <Select
                                                    name="paymentName"
                                                    id="paymentName"
                                                    value={values.paymentName}
                                                    onChange={(opt) => {
                                                        setFieldValue("paymentName", opt);
                                                    }}
                                                    options={this.props.ListPaymentForDrop}
                                                    onBlur={handleBlur}
                                                    error={errors.paymentName}
                                                    touched={touched.paymentName}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.paymentName}
                                                </Form.Control.Feedback>
                                            </Form.Group>

                                        </Col>
                                        <Col>
                                            <Form.Group controlId="money">
                                                <Form.Label> المبلغ</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder="المبلغ "
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="money"
                                                    type="number"
                                                    autoComplete="off"
                                                    value={values.money}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.money}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.money}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>

                                    </Row>
                                    <Row>
                                        <Col>
                                            <Form.Group controlId="emp_name">
                                                <Form.Label> اسم الموظف</Form.Label>
                                                <Form.Control type="text"
                                                    style={{ height: "30px" }}
                                                    placeholder=" "
                                                    onChange={handleChange}
                                                    aria-describedby="inputGroupPrepend"
                                                    name="emp_name"
                                                    autoComplete="off"
                                                    value={values.emp_name}
                                                    onBlur={handleBlur}
                                                    isInvalid={!!errors.emp_name}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                                    {errors.emp_name}
                                                </Form.Control.Feedback>
                                            </Form.Group>
                                        </Col>
                                        <Col>
                                            <Form.Label>صوره الايصال</Form.Label>
                                            <UploadFiles acceptFile="image/*" getfileInfo={this.getImgInfo} />
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
    ListBank: state.reduces.ListBank,
    ListCurrencyForDrop: state.reduces.ListCurrencyForDrop,
    ListBankOutForDrop: state.reduces.ListBankOutForDrop,
    ListPaymentForDrop: state.reduces.ListPaymentForDrop
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Bank);