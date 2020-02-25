import React, { PureComponent } from 'react';
import RequestListViewContainer from '../Components/RequestListView/RequestListViewContainer';

export default class UnassignedRequestsComponent extends PureComponent {
    render() {
        return (<RequestListViewContainer url="https://localhost:5001/api/ticket/unassigned" title="Unassigned requests" />)
    }
}