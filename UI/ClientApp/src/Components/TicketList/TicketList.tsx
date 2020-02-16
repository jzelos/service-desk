import React, { PureComponent } from 'react';
import { TicketListItemModel } from './TicketListItemModel';
import BootstrapTable, { Column } from 'react-bootstrap-table-next';
import filterFactory, { dateFilter, textFilter, numberFilter } from 'react-bootstrap-table2-filter';
import 'react-bootstrap-table2-filter/dist/react-bootstrap-table2-filter.min.css';

// TODO switch out hard coded table columns with component that accepts array of field names
// IE. <td>{ticket[fieldname]}/td>

// https://examples.bootstrap-table.com/#welcomes/from-data.html
// https://react-bootstrap.github.io/components/spinners/ - looks very good

export default class TicketList extends PureComponent<{ tickets: TicketListItemModel[] }> {

    dateFormatter = (cell: Date, row: TicketListItemModel, rowIndex: number, formatExtraData: any) => {
        return cell.toDateString();      
    }

    columns = [{
        dataField: 'id',
        text: 'Ticket ID',
        sort: true,
        filter: numberFilter()
    }, {
        dataField: 'createdDate',
        type:'date',
        text: 'Date Created',
        sort: true, 
        formatter: this.dateFormatter,
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
        return (<BootstrapTable keyField='id' data={this.props.tickets} columns={this.columns as Column[]}  filter={ filterFactory()} /> )
    }
}