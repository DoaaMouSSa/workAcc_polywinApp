import React, { Component, Fragment } from 'react';
import { connect } from 'react-redux';
import actions from '../../redux/actions';
import { bindActionCreators } from "redux";
import { Form, Button } from 'react-bootstrap';
import Confirme from '../Confirme/Confirme';
import ReactTable from '../renderData/renderData';
import toastr from 'toastr'; 
import '../../Design/CSS/custom.css';



class Accounts extends Component {

    constructor(props) {

        super(props);
         
        let userType = JSON.parse(localStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }

        // this is columns of Department
        this.cells = [
            {
                Header: "",
                id: "checkbox",
                accessor: "",
                Cell: (rowInfo) => {
                    return (
                        <Form.Check
                            checked={this.state.selected.indexOf(rowInfo.original.id) > -1}
                            onChange={() => this.toggleRow(rowInfo.original.id)} />
                    );
                },
                sortable: false,
                width: 45
            },
            {
                Header: <strong> إسم الحساب </strong>,
                accessor: 'userName',
                width: 220,
                filterable: true,
            },
            {
                Header: <strong>النوع</strong>,
                accessor: 'userTypeName',
                width: 200,
                filterable: true,
            },
            {
                Header: <strong>كلمه المرور</strong>,
                accessor: 'password',
                width: 200,
                filterable: true,
            }, {
                Header: <strong>الوكيل</strong>,
                accessor: 'managerName',
                width: 200,
                filterable: true,
            }
        ];

        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.ListAccounts && nextState.ListAccounts.length > 0) {

            this.setState({
                isLoading: false,
                showInstallment: false
            });
        } else {
            this.setState({
                isLoading: false,
                showInstallment: false
            });
        }
    };

    // life cycle of react calling when page is loading
    componentDidMount() {
        this.props.actions.getAllAccounts();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            showConfirme: true
        });
    }

    // this function when close modal
    handleClose() {
        this.setState({
            showConfirme: false
        });
    }

    // this function when submit Delete item
    handleConfirm = () => {
        this.setState({
            showConfirme: false,
            selected: []
        });

        this.props.actions.activeAccounts(this.state.selected);


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
                                    <h1 className="main-title float-left">عرض كل الحسابات</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        {/* <h1 className="heading_title">عرض كل الحسابات</h1>*/}
                        {/* Button of Add new Document and delete Row in Grid */}
                        <div className="page-title-actions">
                            {this.state.selected.length > 0 ?
                                <Button size="lg"   onClick={this.showModal.bind(this)}>تفعيل</Button>
                                : null}
                        </div>
                        <br />
                        <br />
                        {/* List Of Data */}
                        <ReactTable
                            data={this.props.ListAccounts}
                            columns={this.cells}
                        />
                    </div>
                </div>
                {this.state.showConfirme ? <Confirme text="هل انت متاكد تفعيل الحسابات ؟؟" show={this.state.showConfirme} handleClose={this.handleClose.bind(this)} handleDelete={this.handleConfirm} /> : null}
            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    ListAccounts: state.reduces.ListAccounts
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(Accounts);