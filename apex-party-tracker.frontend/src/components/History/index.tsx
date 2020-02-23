import React, { useContext, useState } from 'react'
import AppContext from '../../AppContext'
import useParties from '../../hooks/useParties'

interface HistoryProps {
    onUserChange: (user: string) => void
}

const History: React.FC<HistoryProps> = props => {
    const [userInput, setUserInput] = useState<string>('')
    const context = useContext(AppContext)
    const { parties, isFetching, error } = useParties(context.user)

    return (
        <>
            {isFetching ? <pre>Loading</pre> : null}
            {context.user ? (
                <>
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
