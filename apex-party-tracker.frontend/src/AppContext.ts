import React from 'react'

export interface IAppContext {
    user: string
}

export default React.createContext<IAppContext>({ user: '' })
