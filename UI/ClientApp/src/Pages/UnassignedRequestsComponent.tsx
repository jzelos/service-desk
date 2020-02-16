import React, { PureComponent } from 'react';
import TicketViewComponent from './TicketViewComponent';

export default class UnassignedRequestsComponent extends PureComponent {
    render() {
        return (<TicketViewComponent url="http://localhost:58699/api/ticket/unassigned" title="Unassigned requests" />)
    }
}