import React from 'react'
import { NavLink } from 'react-router-dom'
import styles from './styles.module.css'

const Navbar: React.FC = () => {
    return (
        <nav className={styles.navbar}>
            <NavLink to="/" className={styles.brand}>
                Apex Party Tracker
            </NavLink>
            <NavLink to="/history" className={styles.navItem}>
                History
            </NavLink>
        </nav>
    )
}

export default Navbar
