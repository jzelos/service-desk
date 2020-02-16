import React, { PureComponent } from 'react';
import TicketViewComponent from './TicketViewComponent';

export default class MyRequestsComponent extends PureComponent {
    render() {
        return (<TicketViewComponent url="http://localhost:58699/api/ticket" title="My requests" />)
    }
}