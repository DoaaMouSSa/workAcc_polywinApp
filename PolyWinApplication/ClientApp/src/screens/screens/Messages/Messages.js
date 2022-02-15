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

class Messages extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/System/Login");
        }

        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <div>
                    
                        </div>
                    );
                },
                sortable: false,
                width: 30
            },
            {
                Header: <strong>الاسم</strong>,
                accessor: 'name',
                width: 150,
                filterable: true,
            },
            {
                Header: <strong>الهاتف</strong>,
                accessor: 'phone',
                width: 150,
                filterable: true,
            },
            {
                Header: <strong>البريد الالكترونى</strong>,
                accessor: 'email',
                width: 300,
                filterable: true,
            },
            {
                Header: <strong>الرساله</strong>,
                accessor: 'message',
                width: 300,
                filterable: true,
            },

        ];

        this.state = {
            id: 0,
            name: "",
        }
    }
    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.getAllMessages();
    }
    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">رسائل العملاء</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            data={this.props.ListMessage}
                            columns={this.cells}
                        />
                    </div>
                </div>

            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListMessage: state.reduces.ListMessage
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Messages);