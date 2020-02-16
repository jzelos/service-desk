import React, { PureComponent } from 'react';
import { RequestItem } from './RequestItem';
import { reviver } from '../../json-parser';
import RequestListView from './RequestListView';
import LoadingIndicator from '../LoadingIndicator/LoadingIndicator';
import ErrorToast from '../Toasts/ErrorToast';
import EditRequestContainer from '../EditRequest/EditRequestContainer';

interface Props {
    url: string,
    title: string
}

export default class RequestListViewContainer extends PureComponent<Props> {

    readonly state = {
        isLoaded: false,
        tickets: [],
        error: null,
        selectedRequestId: null
    }

    componentDidMount() {

        fetch(this.props.url)
            .then(res => res.text().then(s => JSON.parse(s, reviver)))
            .then(
                (result: RequestItem[]) => {
                    this.setState({
                        isLoaded: true,
                        tickets: result,
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

    selectRequest(row: RequestItem) {
        this.setState({
            selectedRequestId: row.id
        });
    }

    onEditRequestClose() {
        this.setState({
            selectedRequestId: null
        });
    }

    render() {
        return (<div>
            <h1>{this.props.title}</h1>
            {!this.state.isLoaded && <LoadingIndicator />}
            {this.state.isLoaded && this.state.error && <ErrorToast header="Unknown error" body="Could not load data." />}
            {this.state.isLoaded && !this.state.error && <RequestListView tickets={this.state.tickets} onRowSelected={(row)=> this.selectRequest(row)} />}
            {this.state.selectedRequestId && <EditRequestContainer requestId={this.state.selectedRequestId} onClose={() =>this.onEditRequestClose} />}
        </div>)
    }
}