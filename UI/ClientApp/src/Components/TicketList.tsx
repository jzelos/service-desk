import React, { PureComponent } from 'react';

export default class TicketList extends PureComponent<{ tickets: TicketListItemModel[] }> {
    render() {
        return (<table>
            <tr>
                <th>Created</th>
                <th>Assignee</th>
                <th>Status</th>
                <th>Summary</th>
            </tr>
            this.props.tickets.map((item, key) => <TicketListItem ticket={item} />
        </table>)
    }
}