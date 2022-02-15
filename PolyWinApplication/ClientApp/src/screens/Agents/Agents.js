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
//const schema = Yup.object({
//    name: Yup.string().required("برجاء إدخال اسم الوكيل").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
//});


class Agents extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(sessionStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }
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
                Header: <strong>الاسم</strong>,
                accessor: 'name',
                width: 250,
                filterable: true,
            },
            {
                Header: <strong>المحافظه</strong>,
                accessor: 'agentGovernorate',
                width: 100,
                filterable: true,
            },
            {
                Header: <strong>التليفون</strong>,
                accessor: 'agentPhone',
                width: 250,
                filterable: true,
            }, {
                Header: <strong>العنوان</strong>,
                accessor: 'agentAddress',
                width: 350,
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
            objAgent: {
                Id: 0,
                name: "",
                agentGovernorate: "",
                agentPhone: "",
                email: ""
            },
        }
    }
    

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListAgent && nextState.ListAgent.length > 0) {

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
        this.props.actions.getAllAgent();
    }

    // this function when add new data and view modal
    //showModal() {
    //    this.setState({
    //        show: true,
    //        objAgent: {
    //            Id: 0,
    //            name: "",
    //            agentGovernorate: "",
    //            agentPhone: "",
    //            email: ""
    //        }
    //    });
    //}

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

        this.props.actions.deleteAgent(this.state.selected);
        this.props.actions.getAllAgent();
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

    //editAgent= (state, rowInfo, column, instance) => {
    //    const { selection } = this.state;
    //    return {
    //        onClick: (e, handleOriginal) => {
    //            if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
    //                this.setState({
    //                    id: rowInfo.original.id,
    //                    name: rowInfo.original.name,
    //                    objAgent: {
    //                        name: rowInfo.original.name,
    //                        agentGovernorate: rowInfo.original.agentGovernorate,
    //                        agentPhone: rowInfo.original.agentPhone,
    //                        email: rowInfo.original.email
    //                    },
    //                    show: true
    //                });

    //            }
    //        }
    //    };
    //};
    //addeditAgent = (value) => {
    //    this.setState({
    //        isLoading: true
    //    });
    //    alert(value.id)

    //    if (value.id > 0) {
    //        alert("edit")

    //        let obj = {};
    //        obj.id = value.id;
    //        alert(obj.id);
    //        obj.name = value.name;
    //        obj.agentGovernorate = value.agentGovernorate;
    //        obj.agentPhone = value.agentPhone;
    //        obj.email = value.email;
    //        this.props.actions.addeditAgent(obj);
    //        this.handleClose();
    //        this.props.actions.getAllAgent();
    //    } else {
    //        let obj = {};
    //        obj.name = value.name;
    //        obj.agentGovernorate = value.agentGovernorate;
    //        obj.agentPhone = value.agentPhone;
    //        obj.email = value.email;
    //        this.props.actions.addeditAgent(obj);
    //        this.handleClose();
    //        this.props.actions.getAllAgent();
    //    }
    //}



    render() {
        const customProps = { id: 'my' };
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">الوكلاء</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <div className="page-title-actions">
                            {/*<Button size="lg" onClick={this.showModal.bind(this)}>إضافة</Button>*/}
                            {this.state.selected.length > 0 ?
                                <Button size="lg" variant="danger" onClick={this.showDeleteModal.bind(this)}>حذف</Button>
                                : null}
                        </div>
                        {/* List Of Data */}
                        <ReactTable
                            getTrProps={this.editAgent}
                            data={this.props.ListAgent}
                            columns={this.cells}
                            getProps={() => customProps}
                        />
                    </div>
                </div>
                {/*<Modal show={this.state.show} onHide={this.handleClose.bind(this)}>*/}
                {/*    <Modal.Header closeButton>*/}
                {/*        إضافة أو تعديل الوكيل*/}
                {/*    </Modal.Header>*/}
                {/*    <Modal.Body className="modal-header">*/}
                {/*        <Formik validationSchema={schema} onSubmit={(values) => { this.addeditAgent(values) }}*/}
                {/*            initialValues={{*/}
                {/*                id: this.state.id,*/}
                {/*                name: this.state.name,*/}
                {/*                agentGovernorate: this.state.objAgent.agentGovernorate,*/}
                {/*                agentPhone: this.state.objAgent.agentPhone,*/}
                {/*                email: this.state.objAgent.email,*/}
                {/*            }}>*/}
                {/*            {({ handleSubmit, handleChange, handleBlur, values, touched, isValid, errors, }) => (*/}
                {/*                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>*/}
                {/*                    <Form.Group controlId="name">*/}
                {/*                        <Form.Label>اسم الوكيل</Form.Label>*/}
                {/*                        <Form.Control type="text"*/}
                {/*                            style={{ height: "30px" }}*/}
                {/*                            placeholder="اسم الوكيل"*/}
                {/*                            onChange={handleChange}*/}
                {/*                            aria-describedby="inputGroupPrepend"*/}
                {/*                            name="name"*/}
                {/*                            autoComplete="off"*/}
                {/*                            value={values.name}*/}

                {/*                            onBlur={handleBlur}*/}
                {/*                            isInvalid={!!errors.name}*/}

                {/*                        />*/}
                {/*                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>*/}
                {/*                            {errors.name}*/}
                {/*                        </Form.Control.Feedback>*/}
                {/*                    </Form.Group>*/}
                {/*                    <Form.Group controlId="agentGovernorate">*/}
                {/*                        <Form.Label>المحافظه</Form.Label>*/}
                {/*                        <Form.Control type="text"*/}
                {/*                            style={{ height: "30px" }}*/}
                {/*                            placeholder="المحافظه"*/}
                {/*                            onChange={handleChange}*/}
                {/*                            aria-describedby="inputGroupPrepend"*/}
                {/*                            name="agentGovernorate"*/}
                {/*                            autoComplete="off"*/}
                {/*                            value={values.agentGovernorate}*/}
                {/*                            onBlur={handleBlur}*/}
                {/*                            isInvalid={!!errors.agentGovernorate}*/}

                {/*                        />*/}
                {/*                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>*/}
                {/*                            {errors.agentGovernorate}*/}
                {/*                        </Form.Control.Feedback>*/}
                {/*                    </Form.Group>*/}
                {/*                    <Form.Group controlId="agentPhone">*/}
                {/*                        <Form.Label>التليفون</Form.Label>*/}
                {/*                        <Form.Control type="text"*/}
                {/*                            style={{ height: "30px" }}*/}
                {/*                            placeholder="التليفون"*/}
                {/*                            onChange={handleChange}*/}
                {/*                            aria-describedby="inputGroupPrepend"*/}
                {/*                            name="agentPhone"*/}
                {/*                            autoComplete="off"*/}
                {/*                            value={values.agentPhone}*/}
                {/*                            onBlur={handleBlur}*/}
                {/*                            isInvalid={!!errors.agentPhone}*/}

                {/*                        />*/}
                {/*                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>*/}
                {/*                            {errors.agentPhone}*/}
                {/*                        </Form.Control.Feedback>*/}
                {/*                    </Form.Group>*/}
                {/*                    <Form.Group controlId="email">*/}
                {/*                        <Form.Label>البريد الالكترونى</Form.Label>*/}
                {/*                        <Form.Control type="text"*/}
                {/*                            style={{ height: "30px" }}*/}
                {/*                            placeholder="البريد الالكترونى"*/}
                {/*                            onChange={handleChange}*/}
                {/*                            aria-describedby="inputGroupPrepend"*/}
                {/*                            name="email"*/}
                {/*                            autoComplete="off"*/}
                {/*                            value={values.email}*/}
                {/*                            onBlur={handleBlur}*/}
                {/*                            isInvalid={!!errors.email}*/}

                {/*                        />*/}
                {/*                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>*/}
                {/*                            {errors.email}*/}
                {/*                        </Form.Control.Feedback>*/}
                {/*                    </Form.Group>*/}
                {/*                    <div style={{ direction: "ltr" }}>*/}
                {/*                        <Button size="lg" onClick={this.handleClose.bind(this)} style={{ marginRight: '10px' }}>*/}
                {/*                            غلق*/}
                {/*                        </Button>*/}
                {/*                        {this.state.isLoading ? <Button size="lg" disabled  >*/}
                {/*                            <Spinner*/}
                {/*                                as="span"*/}
                {/*                                animation="grow"*/}
                {/*                                size="sm"*/}
                {/*                                role="status"*/}
                {/*                                aria-hidden="true"*/}
                {/*                            />*/}
                {/*                            تحميل*/}
                {/*                        </Button> :*/}
                {/*                            <Button size="lg" variant="success" type="submit">*/}
                {/*                                حفظ*/}
                {/*                            </Button>}*/}
                {/*                    </div>*/}
                {/*                </Form>*/}
                {/*            )}*/}
                {/*        </Formik>*/}
                {/*    </Modal.Body>*/}
                {/*</Modal>*/}

                {this.state.showConfirme ? <Confirme text="هل تريد الحذف ?" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListAgent: state.reduces.ListAgent
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Agents);