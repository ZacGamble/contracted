import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"

class CompaniesService {
    async getCompanies(){
        const res = await api.get("api/companies")
        AppState.companies = res.data
        logger.log("get companies >", res.data)
    }

    async getContractorsByCompanyId(companyId){
        const res = await api.get(`api/companies/${companyId._value}/contractors`)
        AppState.selectedCompanyContractors = res.data
        logger.log("the contractors for selected company > ", res.data)
    }
}

export const companiesService = new CompaniesService()