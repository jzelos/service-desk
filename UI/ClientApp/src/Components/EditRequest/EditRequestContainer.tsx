import React, { PureComponent } from 'react';
import { RequestItem } from './RequestItem';
import { reviver } from '../../json-parser';
import LoadingIndicator from '../LoadingIndicator/LoadingIndicator';
import ErrorToast from '../Toasts/ErrorToast';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';
import EditRequestForm from './EditRequestForm';

interface Props {
    requestId: number | null,
    onClose: () => void
}

interface State {
    isLoaded: boolean,
    request: RequestItem | null,
    error: any  
}

export default class EditRequestContainer extends PureComponent<Props> {

    readonly state: State = {
        isLoaded: false,
        request: null,
        error: null
    }

    componentDidMount() {
        if (this.props.requestId) {
            fetch("http://localhost:58699/api/Ticket/" + this.props.requestId.toString())
                .then(res => res.text().then(s => JSON.parse(s, reviver)))             
                .then(
                (result: RequestItem) => {
                    this.setState({
                        isLoaded: true,
                        request: result,
                        error: null
                    });
                },
                (error) => {
                    this.setState({
                        isLoaded: true,
                        error
                    });
                }); 
        }
        else
        {
            this.setState({
                isLoaded: true,
                request: {},
                error: null
            });
        }
    }

    render() {
        return ( 
            <Modal.Dialog>
                <Modal.Header closeButton>
                    <Modal.Title>Edit Request #{this.props.requestId?.toString()}</Modal.Title>
                </Modal.Header>

                <Modal.Body>
                    {!this.state.isLoaded && <LoadingIndicator />} 
                    {this.state.isLoaded && this.state.error && <ErrorToast header="Unknown error" body="Could not load data." />} 
                    {this.state.isLoaded && this.state.request &&
                        <EditRequestForm request={this.state.request} onClose={() => this.props.onClose()} />
                    }
                </Modal.Body>

                <Modal.Footer>
                    <Button variant="secondary" onClick={this.props.onClose}>Close</Button>
                    <Button variant="primary">Save changes</Button>
                </Modal.Footer>
            </Modal.Dialog>)
    }
}