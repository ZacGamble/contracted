import { api } from "./AxiosService"

class JobsService{
    async getJobs(){
        const res = await api.get('api/jobs')
    }
}

export const jobsService = new JobsService()