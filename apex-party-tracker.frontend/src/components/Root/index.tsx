import React, { useState } from 'react'
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import App from '../App'
import History from '../History'
import AppContext, { IAppContext } from '../../AppContext'

const Root: React.FC = () => {
    const [context, setContext] = useState<IAppContext>({ user: '' })

    return (
        <AppContext.Provider value={context}>
            <Router>
                <Switch>
                    <Route exact path="/history">
                        {' '}
                        <History
                            onUserChange={u => setContext({ user: u })}
                        />{' '}
                    </Route>
                    <Route exact path="/" component={App} />
                </Switch>
            </Router>
        </AppContext.Provider>
    )
}

export default Root
