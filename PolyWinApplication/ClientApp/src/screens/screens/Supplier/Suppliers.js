import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, iframe, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import '../../Design/CSS/custom.css';


// validation of field
const schema = Yup.object({
    supplierName: Yup.string().required("برجاء إدخال اسم المورد").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class Supplier extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/System/Login");
        }
        // this is columns of Supplier
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
                Header: <strong> اسم المورد </strong>,
                accessor: 'supplierName',
                width: 110,
                id:'test',
                filterable: true,
            },
            {
                Header: <strong> كود المورد </strong>,
                accessor: 'supplierCode',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong> اسم الشركه </strong>,
                accessor: 'name',
                width: 100,
                filterable: true,
            }, 
            {
                Header: <strong>تليفون الشركه  </strong>,
                accessor: 'supplierTelephone',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong> عنوان المورد </strong>,
                accessor: 'supplierAddress',
                width: 120,
                filterable: true,
            },
            {
                Header: <strong>  البريد الالكترونى </strong>,
                accessor: 'supplierEmail',
                width: 180,
                filterable: true,
            },
            {
                Header: <strong>  الحد الائتمانى </strong>,
                accessor: 'credit_limit',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong>  مدة االائتمان  </strong>,
                 accessor: 'credit_period',
                width: 100,
                filterable: true,
            }
        ];
        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            id: 0,
            name: "",
            show: false,
            objSupplier: {
                Id: 0,
                name: "",
                supplierName: "",
                supplierCode: "",
                supplierAddress: "",
                supplierTelephone: "",
                supplierPhone: "",
                supplierEmail: "",
                credit_limit: 0,
                credit_period:""
            },
        }
    }
    printPartOfPage(uniqueIframeId) {
        const content = document.getElementsByClassName('ReactTable')[0]
        let pri
        if (document.getElementById(uniqueIframeId)) {
            pri = document.getElementById(uniqueIframeId).contentWindow
        } else {
            const iframe = document.createElement('iframe')
            iframe.setAttribute('title', uniqueIframeId)
            iframe.setAttribute('id', uniqueIframeId)
            iframe.setAttribute('style', 'height: 0px; width: 0px; position: absolute;')
            document.body.appendChild(iframe)
            pri = iframe.contentWindow
        }
        pri.document.open()
        pri.document.write(content.innerHTML)
        pri.document.close()
        pri.focus()
        pri.print()
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListSupplier && nextState.ListSupplier.length > 0) {

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
        this.props.actions.getAllSupplier();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            objSupplier: {
                Id: 0,
                name: "",
                supplierName: "",
                supplierCode: "",
                supplierAddress: "",
                supplierTelephone: "",
                supplierPhone: "",
                supplierEmail: "",
                credit_limit: 10,
                credit_period: "1"
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
            showConfirme: false,
            isLoading: false
        });
    }

    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.deleteSupplier(this.state.selected);
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

    editSupplier = (state, rowInfo, column, instance) => {
        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
                    this.setState({
                        id: rowInfo.original.id,
                        name: rowInfo.original.name,
                        objSupplier: {
                            supplierName: rowInfo.original.supplierName,
                            supplierEmail: rowInfo.original.supplierEmail,
                            supplierTelephone: rowInfo.original.supplierTelephone,
                            supplierPhone: rowInfo.original.supplierPhone,
                            supplierCode: rowInfo.original.supplierCode,
                            supplierAddress: rowInfo.original.supplierAddress,
                            credit_limit: rowInfo.original.credit_limit,
                            credit_period: rowInfo.original.credit_period,
                        },
                        show: true
                    });

                }
            }
        };
    };
    addeditSupplier = (value) => {
        this.setState({
            isLoading: true
        });

        if (value.id > 0) {
       
            let obj = {};
            obj.id = value.id;
            obj.name = value.name;
            obj.supplierName = value.supplierName;
            obj.supplierCode = value.supplierCode;
            obj.supplierAddress = value.supplierAddress;
            obj.supplierTelephone = value.supplierTelephone;
            obj.supplierPhone = value.supplierPhone;
            obj.supplierEmail = value.supplierEmail;
            obj.credit_limit = value.credit_limit;
            obj.credit_period = value.credit_period;
            this.props.actions.addeditSupplier(obj);
            this.handleClose();
            this.props.actions.getAllSupplier();
        } else {
            let obj = {};

            obj.id = value.Id;
            obj.name = value.name;
            obj.supplierName = value.supplierName;
            obj.supplierCode = value.supplierCode;
            obj.supplierAddress = value.supplierAddress;
            obj.supplierTelephone = value.supplierTelephone;
            obj.supplierPhone = value.supplierPhone;
            obj.supplierEmail = value.supplierEmail;
            obj.credit_limit = value.credit_limit;
            obj.credit_period = value.credit_period;
            this.props.actions.addeditSupplier(obj);
            this.handleClose();
            this.props.actions.getAllSupplier();
            } 
            }
        


    render() {
        const customProps = { id: 'my' };
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">الموردين</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            <Button size="lg" onClick={this.showModal.bind(this)}>إضافة</Button>
                            {/*<Button size="lg" onClick={this.printPartOfPage}>PRINT</Button>*/}
                            {this.state.selected.length > 0 ?
                                <Button size="lg" onClick={this.showDeleteModal.bind(this)}>حذف</Button>
                                : null}
                        </div>
                        <br />
                        <br />
                        <iframe id="ifmcontentstoprint" style={{
                            height: '0px',
                            width: '0px',
                            position: 'absolute',
                            color:'red'
                        }} hidden></iframe>


                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editSupplier}
                            data={this.props.ListSupplier}
                            columns={this.cells}
                            getProps={() => customProps}
                            
                        />
                    </div>
                </div>
                <Modal show={this.state.show} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        إضافة أو تعديل المورد
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} onSubmit={(values) => { this.addeditSupplier(values) }}
                            initialValues={{
                                id: this.state.id,
                                name: this.state.name,
                                supplierName: this.state.objSupplier.supplierName,
                                supplierAddress: this.state.objSupplier.supplierAddress,
                                supplierTelephone: this.state.objSupplier.supplierTelephone,
                                supplierPhone: this.state.objSupplier.supplierPhone,
                                supplierEmail: this.state.objSupplier.supplierEmail,
                                credit_period: this.state.objSupplier.credit_period,
                                supplierCode: this.state.objSupplier.supplierCode,
                                credit_limit: this.state.objSupplier.credit_limit,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="supplierName">
                                        <Form.Label>اسم المورد</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="اسم المورد"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="supplierName"
                                            autoComplete="off"
                                            value={values.supplierName}

                                            onBlur={handleBlur}
                                            isInvalid={!!errors.supplierName}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.supplierName}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="supplierCode">
                                            <Form.Label>كود المورد</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="كود المورد"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="supplierCode"
                                            autoComplete="off"
                                            value={values.supplierCode}
                                                onBlur={handleBlur}
                                            isInvalid={!!errors.supplierCode}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.supplierCode}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="name">
                                            <Form.Label>اسم الشركه</Form.Label>
                                            <Form.Control type="text"
                                                style={{ height: "30px" }}
                                            placeholder="اسم الشركه"
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
                                    <Form.Group controlId="supplierAddress">
                                        <Form.Label>عنوان المورد</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="عنوان المورد"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="supplierAddress"
                                            autoComplete="off"
                                            value={values.supplierAddress}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.supplierAddress}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.supplierAddress}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="supplierTelephone">
                                        <Form.Label>تليفون الشركه</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="تليفون الشركه"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="supplierTelephone"
                                            autoComplete="off"
                                            value={values.supplierTelephone}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.supplierTelephone}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.supplierTelephone}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="supplierPhone">
                                        <Form.Label>تليفون المورد</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="تليفون المورد"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="supplierPhone"
                                            autoComplete="off"
                                            value={values.supplierPhone}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.supplierPhone}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.supplierPhone}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="supplierEmail">
                                        <Form.Label>البريد الالكترونى</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="البريد الالكترونى"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="supplierEmail"
                                            autoComplete="off"
                                            value={values.supplierEmail}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.supplierEmail}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.supplierEmail}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="credit_limit">
                                        <Form.Label>الحد الائتمانى</Form.Label>
                                        <Form.Control type="test"
                                            style={{ height: "30px" }}
                                            placeholder="الحد الائتمانى"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="credit_limit"
                                            type="number"
                                            autoComplete="off"
                                            value={values.credit_limit}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.credit_limit}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.credit_limit}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="credit_period">
                                        <Form.Label>مدة الائتمان</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="مدة الائتمان"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="credit_period"
                                            autoComplete="off"
                                            value={values.credit_period}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.credit_period}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.credit_period}
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
    ListSupplier: state.reduces.ListSupplier
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Supplier);