CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] int NOT NULL,
    [RoleId] int NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC, [RoleId] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[UserProfile] ([UserId]),
    FOREIGN KEY ([RoleId]) REFERENCES [dbo].[webpages_Roles] ([RoleId])
);


GO
CREATE NONCLUSTERED INDEX [webpages_UsersInRoles_index]
    ON [dbo].[webpages_UsersInRoles]([RoleId] ASC);