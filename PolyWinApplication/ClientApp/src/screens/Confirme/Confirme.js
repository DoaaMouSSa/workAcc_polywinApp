import React, { Component } from "react";
import { Modal, Button } from 'react-bootstrap';
import '../../Design/CSS/custom.css';

class Confirme extends Component {

    render() {
        return (
            <Modal show={this.props.show} onHide={this.props.handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>رسالة تنبية</Modal.Title>
                </Modal.Header>
                <Modal.Body>{this.props.text}</Modal.Body>
                <Modal.Footer>
                    <Button size="lg" variant="secondary" onClick={this.props.handleClose} style={{ marginRight: '10px' }}>
                        غلق
                    </Button>
                    <Button size="lg" variant="primary" onClick={this.props.handleDelete} style={{ marginRight: '20px' }}>
                        حفظ
                    </Button>
                </Modal.Footer>
            </Modal>
        );
    }
}


export default Confirme;
