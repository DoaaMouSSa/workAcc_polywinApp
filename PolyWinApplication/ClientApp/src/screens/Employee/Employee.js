import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Modal, Spinner, Button, OverlayTrigger, Tooltip } from 'react-bootstrap';
import Select from "react-select";
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr';
import { Formik } from "formik";
import * as Yup from "yup";
import '../../Design/CSS/custom.css';


// validation of field
const schema = Yup.object({
    name: Yup.string().required("برجاء إدخال اسم المشرف").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class Employee extends Component {

    constructor(props) {

        super(props);

        let role_id = JSON.parse(localStorage.getItem("role_id"));

        if (role_id == 3 || role_id == 1 || role_id == 2 || role_id == 4) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }

        // this is columns of Store
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
                Header: <strong> اسم المشرف </strong>,
                accessor: 'name',
                width: 200,
                filterable: true,
            },
        
            {
                Header: <strong>الرقم السرى</strong>,
                accessor: 'password',
                width: 200,
                filterable: true,
            }
            ,
        
            {
                Header: <strong>الوظيفه</strong>,
                accessor: 'roles_name',
                width: 200,
                filterable: true,
            }
        ];

        // initial value of state
        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
           
            show: false,
            objEmployee: {
                Id: 0,
                name: "",
                password: "",
                role: "",
            }
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListStore && nextState.ListStore.length > 0) {

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
        this.props.actions.GetEmployee();
        this.props.actions.getAllRolesDD();
    }


 // this function when add new data and view modal
 showModal() {
    this.setState({
        show: true,
        objEmployee: {
            Id: 0,
            name: "",
            password: "",
            role: "",
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

    this.props.actions.deleteEmployee(this.state.selected);
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
    editEmployee = (state, rowInfo, column, instance) => {

        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
                    let obj = this.state.objEmployee;


                    obj.role = { value: rowInfo.original.id, label: rowInfo.original.role_name };
                    obj.name = rowInfo.original.name;
                    obj.password = rowInfo.original.password;
                    obj.Id = rowInfo.original.id;

                    this.setState({
                        objEmployee: obj,
                        show: true
                    });
                }
            }
        };
    };

    addEditEmployee = (value) => {
        this.setState({
            isLoading: true
        });
        if (value.id > 0) {
        let obj = {};
        obj.id = value.Id;
        obj.name = value.name;
        obj.password = value.password;
            obj.roles_id = value.role.value;
        this.props.actions.addEditEmployee(obj);
        }else{
            let obj = {};
            obj.id = value.Id;
            obj.name = value.name;
            obj.password = value.password;
            obj.roles_id = value.role.value;
            this.props.actions.addEditEmployee(obj);
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
                                    <h1 className="main-title float-left">المشرفين</h1>
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
                            getTrProps={this.editEmployee}
                            data={this.props.ListEmployee}
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
                                this.addEditEmployee(values)
                            }}
                            initialValues={{
                                Id: this.state.objEmployee.Id,
                                name: this.state.objEmployee.name,
                                password: this.state.objEmployee.password,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, setFieldValue, setFieldTouched, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                   
                                    <Form.Group controlId="name">
                                    <Form.Label>اسم المشرف </Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder=""
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
                                    <Form.Group controlId="password">
                                    <Form.Label>الرقم السرى </Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder=""
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="password"
                                            autoComplete="off"
                                            value={values.password}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.password}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.password}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    <Form.Group controlId="role">
                                                <Form.Label> الوظيفه</Form.Label>
                                                <Select
                                                    name="role"
                                                    value={values.role}
                                                    onChange={(opt) => {
                                                        setFieldValue("role", opt);
                                                    }}
                                                    options={this.props.ListRoleDD}
                                                    onBlur={handleBlur}
                                                    error={errors.role}
                                                    touched={touched.role}
                                                />
                                                <Form.Control.Feedback type="invalid" style={{ display: 'inline-block', color: "red" }}>
                                                    {errors.role}
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
    ListEmployee: state.reduces.ListEmployee,
    ListRoleDD:state.reduces.ListRoleDD
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Employee);