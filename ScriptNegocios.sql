use Negocios2021
go


Alter table RRHH.empleados
add activo bit
go

update RRHH.empleados set Activo=1
go

create proc usp_listadoEmpleado
as
begin
select IdEmpleado,ApeEmpleado,NomEmpleado,FecNac,DirEmpleado,idDistrito,fonoEmpleado,idCargo,FecContrata from RRHH.empleados 
where Activo = 1
end
go

create proc usp_listadoCargo
as
begin
select idcargo,desCargo from RRHH.Cargos
end
go

exec usp_listadoCargo
go

create proc usp_listadoDistrito
as
begin
select idDistrito, nomDistrito from RRHH.Distritos
end
go

exec usp_listadoDistrito
go

alter proc usp_agregarEmpleado
@apellido varchar(50),
@nombre	varchar(50),
@fecNac datetime,
@direccion varchar(60),
@idDistrito int,
@fonoEmpleado varchar(15),
@idCargo int,
@fecContrata datetime
as
begin
insert into RRHH.empleados(ApeEmpleado,NomEmpleado,FecNac,DirEmpleado,idDistrito,fonoEmpleado,idCargo,FecContrata,activo) values(@apellido,@nombre,@fecNac,@direccion,@idDistrito,@fonoEmpleado,@idCargo,@fecContrata,1)
end
go


create proc usp_actualizarEmpleado
@idEmpleado int,
@apellido varchar(50),
@nombre	varchar(50),
@fecNac datetime,
@direccion varchar(60),
@idDistrito int,
@fonoEmpleado varchar(15),
@idCargo int,
@fecContrata datetime
as
begin
update RRHH.empleados set ApeEmpleado= @apellido, NomEmpleado = @nombre, FecNac = @fecNac, DirEmpleado = @direccion, idDistrito = @idDistrito, fonoEmpleado = @fonoEmpleado, idCargo = @idCargo, FecContrata = @fecContrata where IdEmpleado = @idEmpleado
end
go

create proc usp_empleadoBaja
@idEmpleado int
as
begin
update RRHH.empleados set activo=0 where idEmpleado=@idEmpleado
end
go

exec usp_empleadoBaja 10
go


create proc usp_empleadodatos
@idEmpleado int
as
begin
	select IdEmpleado,ApeEmpleado,NomEmpleado,FecNac,DirEmpleado,idDistrito,fonoEmpleado,idCargo,FecContrata from RRHH.empleados where idEmpleado = @idEmpleado
end
go


create proc usp_listadoProducto
as
begin
	select IdProducto,NomProducto,IdCategoria,IdProveedor,CantxUnidad,PrecioUnidad,UnidadesEnExistencia from Compras.productos
	order by 1 asc
end 
go

create proc usp_buscarProducto
@nomProducto varchar(40),
@idCategoria int
as
begin
	select IdProducto,NomProducto,IdCategoria,IdProveedor,CantxUnidad,PrecioUnidad,UnidadesEnExistencia from Compras.productos
	where NomProducto Like '%'+@nomProducto+'%' and  IdCategoria =@idCategoria
end 
go

create proc usp_categorialistar
as
begin
	select IdCategoria,NombreCategoria from Compras.categorias
end
go

exec usp_listadoEmpleado
select * from RRHH.empleados