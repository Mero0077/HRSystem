namespace HRSystem.Common.Enums
{
    public enum SystemFeature
    {
        // Organization Management
        Organization_Create = 1,
        Organization_Read = 2,
        Organization_Update = 3,
        Organization_Delete = 4,

        // Company Management
        Company_Create = 10,
        Company_Read = 11,
        Company_Update = 12,
        Company_Delete = 13,

        // Department Management
        Department_Create = 20,
        Department_Read = 21,
        Department_Update = 22,
        Department_Delete = 23,

        // Branch Management
        Branch_Create = 30,
        Branch_Read = 31,
        Branch_Update = 32,
        Branch_Delete = 33,

        // User Management
        User_Create = 40,
        User_Read = 41,
        User_Update = 42,
        User_Delete = 43,
        User_ResetPassword = 44,
        User_AssignRoles = 45,

        // Role Management
        Role_Create = 50,
        Role_Read = 51,
        Role_Update = 52,
        Role_Delete = 53,
        Role_AssignFeatures = 54,

        // Feature Management
        Feature_Create = 60,
        Feature_Read = 61,
        Feature_Update = 62,
        Feature_Delete = 63,

        // UserRole Management
        UserRole_Remove = 70,

        // RoleFeature Management
        RoleFeature_Remove = 80,
    }
}
