import React, { PureComponent } from 'react';
import TicketViewComponent from './TicketViewComponent';

export default class MyTeamsRequestsComponent extends PureComponent {
    render() {
        return (<TicketViewComponent url="http://localhost:58699/api/ticket/myteam" title="My teams requests" />)
    }
}