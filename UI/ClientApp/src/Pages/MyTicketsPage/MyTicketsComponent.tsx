import React, { PureComponent } from 'react';
import TicketList from '../../Components/TicketList/TicketList';
import { TicketListItemModel } from '../../Components/TicketList/TicketListItemModel';
import { reviver } from '../../json-parser';

export default class MyTicketsComponent extends PureComponent {

    readonly state = {
        unassignedTicketsLoaded: false,
        unassignedTickets: [],
        myTicketsLoaded: false,
        myTickets: []
    }

    componentDidMount() {

        const username = "jay";

        fetch("http://localhost:58699/api/ticket")
            .then(res => res.text().then(s => JSON.parse(s, reviver)))            
            .then(
            (result: TicketListItemModel[]) => {
                this.setState({
                    myTicketsLoaded: true,
                    myTickets: result
                });
            },
            (error: any) => {
                this.setState({
                    myTicketsLoaded: true,
                    error
                });
            });  
            
            fetch("http://localhost:58699/api/ticket/unassigned")
            .then(res => res.text().then(s => JSON.parse(s, reviver))) 
            .then(
            (result: TicketListItemModel[]) => {
                this.setState({
                    unassignedTicketsLoaded: true,
                    unassignedTickets: result
                });
            },
            (error) => {
                this.setState({
                    unassignedTicketsLoaded: true,
                    error
                });
            }); 
    }
    
    render() {
        return (<div>
            <h1>Unassigned Tickets</h1>
            {this.state.unassignedTicketsLoaded && <TicketList tickets={this.state.unassignedTickets} />}

            <h1>My Tickets</h1>
            {this.state.myTicketsLoaded && <TicketList tickets={this.state.myTickets} />}     
        </div>)
    }
}