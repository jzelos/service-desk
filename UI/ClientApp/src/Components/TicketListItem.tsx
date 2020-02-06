import React, { PureComponent } from 'react';

export default class TicketListItem extends PureComponent<{ ticket: TicketListItemModel }> {
    render() {
        return (
            <tr>
                <td>{{ this.props.ticket.created }}</td>
                <td>{{ this.props.ticket.assignee }}</td>
                <td>{{ this.props.ticket.status }}</td>
                <td>{{ this.props.ticket.summary }}</td>
            </tr>)
    }
}