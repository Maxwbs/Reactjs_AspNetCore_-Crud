import React from 'react'
import './Main.css'
import Header from './Header'
// main será nosso executavel

export default props =>
/* componente pode retornar  multiplos elementos. Os fragmentos
* permitem agrupar uma lista de filhos sem adicionar nós extras ao
* DOM. para usarmos o header*/
  <React.Fragment>
    <Header {...props} />
    <main className = "content">
        <div className = "p-4 mt-4">
            {props.children}
        </div>
    </main>
  </React.Fragment>
  