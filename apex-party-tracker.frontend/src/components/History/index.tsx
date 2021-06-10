import React, { useContext, useState, useEffect } from 'react'
import AppContext from '../../AppContext'
import useParties from '../../hooks/useParties'
import Navbar from '../Navbar'

interface HistoryProps {
    onUserChange: (user: string) => void
}

const History: React.FC<HistoryProps> = props => {
    const [userInput, setUserInput] = useState<string>('')
    const context = useContext(AppContext)
    const { parties, isFetching, error } = useParties(context.user)

    useEffect(() => {
        useParties(context.user)
    }, [context])

    return (
        <>
            <Navbar />
            {isFetching ? <pre>Loading</pre> : null}
            {context.user ? (
                <>
                    <h1>{context.user}</h1>
                    {parties ? (
                        parties.map(p => (
                            <div key={p.eTag}>
                                <pre>{JSON.stringify(p)}</pre>
                            </div>
                        ))
                    ) : (
                        <h1>No parties found</h1>
                    )}
                </>
            ) : (
                <>
                    <label>Username: </label>
                    <input
                        type="text"
                        value={userInput}
                        onChange={e => setUserInput(e.target.value)}
                    />
                    <button onClick={() => props.onUserChange(userInput)}>
                        Submit
                    </button>
                </>
            )}
        </>
    )
}

export default History
