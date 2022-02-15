import React, { Component } from 'react';
import 'react-dropzone-uploader/dist/styles.css';
import Dropzone from 'react-dropzone-uploader';
 
class UploadFiles extends Component {
    constructor(props) {
        super(props);
    }

    // specify upload params and url for your files
    //getUploadParams = ({ file, meta }) => {

    //    const body = new FormData();

    //    body.append('fileUpload', file);

    //    const headers = {
    //        DocumentType: this.props.docType,
    //        DocID: this.props.docId,
    //        Authorization: localStorage.getItem('token')
    //    }

    //    const url = Config.defaultURLAPI() + '/UploadFiles';

    //    return { url, body, headers: headers }
    //}

    // called every time a file's `status` changes
    handleChangeStatus = ({ meta, file }, status) => {
        console.log(status, meta, file)
        this.props.getfileInfo(file);
    }

    // receives array of files that are done uploading when submit button is clicked
    // handleSubmit = (files, allFiles) => {
    //     console.log(files.map(f => f.meta))
    //     allFiles.forEach(f => f.remove())
    // }

    //accept="image/*,audio/*,video/*"
     
    render() {
        return (
            <Dropzone
                //getUploadParams={this.getUploadParams}
                onChangeStatus={this.handleChangeStatus}
               // onSubmit={this.handleSubmit}
                maxFiles={1}
                multiple={false}
                canCancel={true}
                // accept="image/*"
                accept={this.props.acceptFile}
                inputContent="برجاء اختيار الملفات"
            />
        );
    }

}


export default UploadFiles;
