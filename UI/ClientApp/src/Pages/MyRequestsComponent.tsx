import React, { PureComponent } from 'react';
import RequestListViewContainer from '../Components/RequestListView/RequestListViewContainer';

export default class MyRequestsComponent extends PureComponent {
    render() {
        return (<RequestListViewContainer url="http://localhost:58699/api/ticket" title="My requests" />)
    }
}