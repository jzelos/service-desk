import React from 'react';
import './App.css';
import NavBarComponent from './Pages/NavBarComponent';
import { Route, Link, BrowserRouter as Router } from 'react-router-dom'
import UnassignedRequestsComponent from './Pages/UnassignedRequestsComponent';
import MyRequestsComponent from './Pages/MyRequestsComponent';
import MyTeamsRequestsComponent from './Pages/MyTeamsRequestsComponent';
import EditRequestContainer from './Components/EditRequest/EditRequestContainer';

const App = () => {
  return (
    <div className="app"> 
      <NavBarComponent />
      <div className="body">                
        <Router>
          <Route path="/myrequests" component={MyRequestsComponent} />
          <Route path="/myteamsrequests" component={MyTeamsRequestsComponent} />
          <Route path="/unassignedrequests" component={UnassignedRequestsComponent} />
          <Route path="/editrequest" component={EditRequestContainer} />
        </Router>
      </div>            
    </div>
  );
}

export default App;