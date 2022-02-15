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
    storeName: Yup.string().required("برجاء إدخال اسم المخزن").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});


class Store extends Component {

    constructor(props) {

        super(props);

        var role_id = JSON.parse(localStorage.getItem("role_id"));
        if ((role_id == 2) || (role_id == 1 )) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }
        // this is columns of Store
        this.cells = [
            //{
            //    Header: "",
            //    id: "checkbox",
            //    accessor: "",
            //    Cell: (rowInfo) => {
            //        return (
            //            <div>
            //                <Form.Check
            //                    checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
            //                    onChange={() => this.toggleRow(rowInfo.original.id)} />
            //            </div>
            //        );
            //    },
            //    sortable: false,
            //    width: 30
            //}, 
            {
                Header: <strong> المنتج </strong>,
                accessor: 'productName',
                width: 200,
                filterable: true,
            },
        
            {
                Header: <strong>الكميه</strong>,
                accessor: 'quantity',
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
            name: "",
            show: false,
            objStore: {
                Id: 0,
                ProductName:"",
                Qty:"",
            },
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
        this.props.actions.getAllStore();
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
    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left"> المخزن الرئيسى</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
            
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            data={this.props.ListStore}
                            columns={this.cells}
                        />
                    </div>
                </div>
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListStore: state.reduces.ListStore
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Store);