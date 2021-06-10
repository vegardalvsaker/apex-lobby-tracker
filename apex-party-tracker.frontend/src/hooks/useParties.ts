import { useEffect, useState } from 'react'
import { Party } from '../models/party'
import { Error } from '../types/error'
import { BACKEND_URL, PARTIES_ENDPOINT } from '../constants'

export default (user: string) => {
    const [parties, setParties] = useState<Party[]>([])
    const [isFetching, setIsFecthing] = useState<boolean>(false)
    const [error, setError] = useState<Error>()

    const fetchParties = async () => {
        setIsFecthing(true)
        const options = {
            headers: {
                'Content-Type': 'application/json',
            },
            method: 'GET',
        }
        const response = await fetch(
            `${BACKEND_URL}${PARTIES_ENDPOINT}/${user}`,
            options
        )
        if (response.ok) {
            const results = (await response.json()) as Party[]
            setIsFecthing(false)
            setParties(results)
        } else {
            const error: Error = {
                title: response.statusText,
                message: response.statusText,
                status: response.status,
            }
            setError(error)
        }
    }

    useEffect(() => {
        console.log('Gurine')
        if (user) fetchParties()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    return { parties, isFetching, error }
}
