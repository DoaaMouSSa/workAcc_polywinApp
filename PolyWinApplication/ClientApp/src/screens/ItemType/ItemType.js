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
import '../../Design/CSS/custom.css';


// validation of field
const schema = Yup.object({
    nameItemType: Yup.string().required("برجاء إدخال اسم الوحده").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class ItemType extends Component {

    constructor(props) {

        super(props);

        let role_id = JSON.parse(localStorage.getItem("role_id"));
        if (role_id == 3 || role_id == 1 || role_id == 2 || role_id==4) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }

        // this is columns of ItemType
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
                Header: <strong> اسم الوحده </strong>,
                accessor: 'nameItemType',
                width: 150,
                filterable: true,
            }
         
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            id: 0,
            nameItemType: "",
            show: false,
         
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListItemType && nextState.ListItemType.length > 0) {

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
        this.props.actions.getAllItemType();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
           
                Id: 0,
            nameItemType: "",
            
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

        this.props.actions.DeleteItemType(this.state.selected);
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

    editItemType = (state, rowInfo, column, instance) => {
        const { selection } = this.state;
        return {
            onClick: (e, handleOriginal) => {
                if (e.target.type !== "checkbox" && (e.target.className === "Edit" || e.target.className === "rt-td")) {
                    this.setState({
                        id: rowInfo.original.id,
                        nameItemType: rowInfo.original.nameItemType,
                        show: true
                    });

                }
            }
        };
    };
    addeditItemType = (value) => {
        this.setState({
            isLoading: true
        });

        if (value.id > 0) {

            let obj = {};
            obj.id = value.id;
            obj.nameItemType = value.nameItemType;
            this.props.actions.AddEditItemType(obj);
            this.handleClose();
            this.props.actions.getAllItemType();
        } else {

            let obj = {};

            obj.id = value.id;
            obj.nameItemType = value.nameItemType;
            this.props.actions.AddEditItemType(obj);
            this.handleClose();
            this.props.actions.getAllItemType();
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
                                    <h1 className="main-title float-left">الوحدات</h1>
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
                            getTrProps={this.editItemType}
                            data={this.props.ListItemType}
                            columns={this.cells}
                        />
                    </div>
                </div>
                <Modal show={this.state.show} onHide={this.handleClose.bind(this)}>
                    <Modal.Header closeButton>
                        إضافة أو تعديل الوحده
                    </Modal.Header>
                    <Modal.Body className="modal-header">
                        <Formik validationSchema={schema} onSubmit={(values) => { this.addeditItemType(values) }}
                            initialValues={{
                                id: this.state.id,
                                nameItemType: this.state.nameItemType,
                            
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="nameItemType">
                                        <Form.Label>اسم الوحده</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "30px" }}
                                            placeholder="اسم الوحده"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="nameItemType"
                                            autoComplete="off"
                                            value={values.nameItemType}

                                            onBlur={handleBlur}
                                            isInvalid={!!errors.nameItemType}

                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.nameItemType}
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
    ListItemType: state.reduces.ListItemType
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(ItemType);