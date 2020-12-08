import React from 'react'
import { Switch, Route, Redirect } from 'react-router-dom'
import MembroCrud from '../membro/membro';
import ParametrizacaoGeral from '../parametrizacaoGeral/parametrizacaoGeral';
import ExporteCredencial from '../exportecredencial/exportecredencial';

export default props =>    
        <Switch>
            <Route exact path='/' component={MembroCrud} />
            <Route path='/Membro' component={MembroCrud} />
            <Route path='/ParametrizacaoGeral' component={ParametrizacaoGeral} />
            <Route path='/ExporteCredencial' component={ExporteCredencial} />
            <Redirect from= '*' to= '/'/>
        </Switch>


