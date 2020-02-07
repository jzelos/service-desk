import React, { PureComponent } from 'react';
import { TicketListItemModel } from './TicketListItemModel';
import TicketListItem from './TicketListItem';
import BootstrapTable, { Column } from 'react-bootstrap-table-next';
import filterFactory, { dateFilter, textFilter, numberFilter } from 'react-bootstrap-table2-filter';
import 'react-bootstrap-table2-filter/dist/react-bootstrap-table2-filter.min.css';

// TODO switch out hard coded table columns with component that accepts array of field names
// IE. <td>{ticket[fieldname]}/td>

export default class TicketList extends PureComponent<{ tickets: TicketListItemModel[] }> {

    columns = [{
        dataField: 'id',
        text: 'Ticket ID',
        sort: true,
        filter: numberFilter()
    }, {
        dataField: 'createdDate',
        text: 'Date Created',
        sort: true, 
        filter: dateFilter()
    }, {
        dataField: 'assignee',
        text: 'Assignee',
        sort: true,
        filter: textFilter()
    },
    {
        dataField: 'status',
        text: 'Status',
        sort: true,
        filter: textFilter()
    },
    {
        dataField: 'summary',
        text: 'Summary',
        sort: true,
        filter: textFilter()
    }];


    render() {
        return (
            <div>
{/*                 <table>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Created</th>
                            <th>Assignee</th>
                            <th>Status</th>
                            <th>Summary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {this.props.tickets.map((item, key) => <TicketListItem ticket={item} key={item.id} />)}
                    </tbody>
                </table> */}
                <BootstrapTable keyField='id' data={this.props.tickets} columns={this.columns as Column[]}  filter={ filterFactory() } />
            </div>)
    }
}