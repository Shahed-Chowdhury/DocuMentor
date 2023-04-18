import { Role } from "./role";

export interface RoleDTO {
    status: string,
    data: Array<Role>
}

export interface CreateUpdateRoleDTO {
    name: string
}