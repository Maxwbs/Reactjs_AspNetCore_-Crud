import React from 'react'
import './Nav.css'

export default props =>
	<aside className="menu-area">
		<nav className="menu">			

			{/* <a href='#/parametrizacaoGeral'>
				<i className="fa fa-sitemap"></i> Parametrização Credencial
		</a> */}
		<a href='#/parametrizacaoGeral'>
				<i className="fa fa-sitemap"></i> Parametrização Credencial
		</a>

			<a href='#/membro'>
				<i className="fa fa-user"></i> Membros
		</a>

		<a href='#/exportecredencial'>
				<i className="fa fa-user"></i> Gere Credencial
		</a>
		</nav>
	</aside>
