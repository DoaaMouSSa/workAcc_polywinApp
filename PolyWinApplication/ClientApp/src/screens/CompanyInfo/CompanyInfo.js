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
import UploadFiles from "../../components/FileUpload/UploadFiles";
import '../../Design/CSS/custom.css';

// validation of field
const schema = Yup.object({
    companyInfo: Yup.string().required("برجاء إدخال معلومات عن الشركة").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
    futureInfo: Yup.string().required("برجاء إدخال نافذة عن المستقبل").max(200, "الحد الاقصى للكتابة 200 حرف فقط"),
});

class CompanyInfo extends Component {

    constructor(props) {

        super(props);

        let userType = JSON.parse(sessionStorage.getItem("UserType"));

        if (userType !== 1) {
            toastr.error("عفوا ليس لديك صلاحية لهذة الصفحة");
            this.props.history.push("/Login");
        }


        // initial value of state

        this.state = {
            selected: [],
            isLoading: false,
            showConfirme: false,
            companyInfo: "",
            futureInfo: "",
            id: 0,
            ImagePath: "",
            show: false,
            showImage: false
        }
    }

    // life cycle of react calling when any change of props
    componentWillReceiveProps(nextState, prevState) {
        if (nextState.objCompanyInfo) {

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
        this.props.actions.getCompanyInfo();
    }

    // this function when add new data and view modal
    showModal() {
        this.setState({
            show: true,
            description: "",
            ImagePath: "",
            file: "",
            id: 0
        });
    }

    showDeleteModal() {
        this.setState({
            showConfirme: true
        });
    }


    // this function when leave from page
    componentWillUnmont() {
        this.setState({
            show: false,
            isLoading: false,
            showConfirme: false
        });
    }

    getfileInfo = (files) => {
        this.setState({
            file: files
        });
    }

    addEditCompanyInfo = (value) => {
        this.setState({
            isLoading: true
        });


        const body = new FormData();

        body.append('file', this.state.file);
        body.append('FutureInfo', value.futureInfo);
        body.append('CompanyInfo', value.companyInfo);

        this.props.actions.addEditCompanyInfo(body);
    }

    render() {
        return (
            <div className="content-page">
                <div className="content">
                    <div className="container-fluid">
                        <div className="row">
                            <div className="col-xl-12">
                                <div className="breadcrumb-holder">
                                    <h1 className="main-title float-left">معلومات عن الشركة</h1>
                                    <div className="clearfix"></div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <br />
                        <Formik enableReinitialize validationSchema={schema} onSubmit={(values) => { this.addEditCompanyInfo(values) }}
                            initialValues={{
                                companyInfo: this.props.objCompanyInfo.companyInfo,
                                futureInfo: this.props.objCompanyInfo.futureInfo,
                            }}>
                            {({ handleSubmit, handleChange, handleBlur, values, touched, isValid, errors, }) => (
                                <Form noValidate onSubmit={handleSubmit} style={{ fontWeight: 'bold', fontSize: '25px', width: '100%' }}>
                                    <Form.Group controlId="companyInfo">
                                        <Form.Label>معلومات عن الشركة</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="معلومات عن الشركة"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="companyInfo"
                                            autoComplete="off"
                                            value={values.companyInfo}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.companyInfo}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.companyInfo}
                                        </Form.Control.Feedback>
                                    </Form.Group>

                                    <Form.Group controlId="futureInfo">
                                        <Form.Label>نافذة المستقبل</Form.Label>
                                        <Form.Control type="text"
                                            style={{ height: "50px" }}
                                            placeholder="نافذة المستقبل"
                                            onChange={handleChange}
                                            aria-describedby="inputGroupPrepend"
                                            name="futureInfo"
                                            autoComplete="off"
                                            value={values.futureInfo}
                                            onBlur={handleBlur}
                                            isInvalid={!!errors.futureInfo}
                                        />
                                        <Form.Control.Feedback type="invalid" style={{ color: "red" }}>
                                            {errors.futureInfo}
                                        </Form.Control.Feedback>
                                    </Form.Group>
                                    {this.props.objCompanyInfo.companyFile !== null ?
                                        <OverlayTrigger
                                            key={`topupdate-${this.props.objCompanyInfo.companyFile}`}
                                            placement={'top'}
                                            overlay={
                                                <Tooltip id={`tooltip-top`}>
                                                    <strong>الملف</strong>
                                                </Tooltip>
                                            }>
                                            <a variant="danger" href={this.props.objCompanyInfo.companyFile} target="_blank">عرض الملف</a>
                                        </OverlayTrigger> : null
                                    }
                                    <UploadFiles acceptFile="application/pdf" getfileInfo={this.getfileInfo} />

                                    <div style={{ direction: "ltr" }}>
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
                    </div>
                </div>

            </div>
        );
    }
}


const mapStateToProps = (state, ownProps) => ({
    objCompanyInfo: state.reduces.objCompanyInfo
});

const mapDispatchToProps = (dispatch, ownProps) => ({
    actions: bindActionCreators(actions, dispatch)
});

export default connect(mapStateToProps, mapDispatchToProps)(CompanyInfo);