export interface Party {
    players: string
    deleted: boolean
    dateDeleted: string | null
    partitionKey: string
    timestamp: string
    eTag: string
}
