import React, { PureComponent } from 'react';
import RequestListViewContainer from '../Components/RequestListView/RequestListViewContainer';

export default class MyTeamsRequestsComponent extends PureComponent {
    render() {
        return (<RequestListViewContainer url="http://localhost:58699/api/ticket/myteam" title="My teams requests" />)
    }
}