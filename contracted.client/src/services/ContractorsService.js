import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class ContractorsService {
    async getContractors(){
        const res = await api.get('api/contractors')
        AppState.contractors = res.data
        logger.log('get Contractors > ', res.data)
    }
}

export const contractorsService = new ContractorsService()