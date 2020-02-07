import React from 'react';
import { TicketListItemModel } from './TicketListItemModel';


export const TicketListItem: React.FunctionComponent<{ ticket: TicketListItemModel }> = (props) => {
    return (
        <tr>
            <td>{props.ticket.id}</td>
            <td>{props.ticket.createdDate}</td>
            <td>{props.ticket.assignee}</td>
            <td>{props.ticket.status}</td>
            <td>{props.ticket.summary}</td>
        </tr>)
};

export default TicketListItem;
