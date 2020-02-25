import React, { PureComponent } from 'react';
import RequestListViewContainer from '../Components/RequestListView/RequestListViewContainer';

export default class MyRequestsComponent extends PureComponent {
    render() {
        return (<RequestListViewContainer url="https://localhost:5001/api/ticket" title="My requests" />)
    }
}