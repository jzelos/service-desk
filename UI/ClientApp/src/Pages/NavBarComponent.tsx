import React, { PureComponent } from 'react';
import Navbar from 'react-bootstrap/NavBar';
import Nav from 'react-bootstrap/Nav';
import Button from 'react-bootstrap/Button';

export default class NavBarComponent extends PureComponent {
    render() {
        return (
            <Navbar bg="light" expand="lg">
            <Navbar.Brand href="#home">Service Desk</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="mr-auto">
                <Nav.Link href="myrequests">My Requests</Nav.Link>
                <Nav.Link href="myteamsrequests">My Teams Requests</Nav.Link>
                <Nav.Link href="unassignedrequests">Unassigned Requests</Nav.Link>
{/*                 <NavDropdown title="Dropdown" id="basic-nav-dropdown">
                    <NavDropdown.Item href="#action/3.1">Action</NavDropdown.Item>
                    <NavDropdown.Item href="#action/3.2">Another action</NavDropdown.Item>
                    <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                    <NavDropdown.Divider />
                    <NavDropdown.Item href="#action/3.4">Separated link</NavDropdown.Item>
                </NavDropdown> */}
                </Nav>
                <Button variant="outline-success" href="editrequest">New Request</Button>
            </Navbar.Collapse>
            </Navbar>);
    }
}