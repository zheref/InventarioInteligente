create table INVENTARIO
(
	CODEINV		int			auto_increment	not null,
	FECHA		datetime					not null,

	constraint PK_INVENTARIO primary key (CODEINV)
);

create table VENTA
(
	CODEVEN		int			auto_increment	not null,
	FECHA		datetime					not null,

	constraint PK_VENTA primary key (CODEVEN)
);

create table PROVEEDOR
(
	NIT			char(14)					not null,
	NOMBRE		varchar(15)					not null,
	FOTO		varchar(10)					null,

	constraint PK_PROVEEDOR primary key (NIT)
);

create table PRODUCTO
(
	BARCODE		char(20)					not null,
	NOMBRE		varchar(20)					not null,
	FOTO		varchar(10)					null,
	CADUC		datetime					null,

	NIT			char(14)					not null,

	constraint PK_PRODUCTO primary key (BARCODE),

	constraint FK_PROVEEDOR_OFRECE_PRODUCTO foreign key (NIT) references PROVEEDOR (NIT)
);

create table PEDIDO
(
	CODEPED		int			auto_increment	not null,
	FECHA		datetime					not null,
	LLEGADA		datetime					null,

	NIT			char(14)					not null,

	constraint PK_PEDIDO primary key (CODEPED),

	constraint FK_PROVEEDOR_GESTIONA_PEDIDO foreign key (NIT) references PROVEEDOR (NIT)
);

create table COMPRA
(
	CODECOM		int			auto_increment	not null,
	FECHA		datetime					not null,

	CODEPED		int							null,
	NIT			char(14)					not null,

	constraint PK_COMPRA primary key (CODECOM),

	constraint FK_COMPRA_ENBASE_PEDIDO foreign key (CODEPED) references PEDIDO (CODEPED),
	constraint FK_COMPRA_A_PROVEEDOR foreign key (NIT) references PROVEEDOR (NIT)
);

create table ITEMINVENT
(
	CODEINV		int							not null,
	BARCODE		char(20)					not null,

	CANTIDAD	tinyint						not null,

	constraint PK_ITEMINVENT primary key (CODEINV, BARCODE),

	constraint FK_PRODUCTO_ALMACENADO_INVENTARIO foreign key (CODEINV) references INVENTARIO (CODEINV),
	constraint FK_INVENTARIO_ALMACENA_PRODUCTO foreign key (BARCODE) references PRODUCTO (BARCODE)
);

create table ITEMVENTA
(
	CODEVEN		int							not null,
	BARCODE		char(20)					not null,

	CANTIDAD	tinyint						not null,

	constraint PK_ITEMVENTA primary key (CODEVEN, BARCODE),

	constraint FK_PRODUCTO_VENDIDO_VENTA foreign key (CODEVEN) references VENTA (CODEVEN),
	constraint FK_VENTA_FACTURA_PRODUCTO foreign key (BARCODE) references PRODUCTO (BARCODE)
);

create table ITEMPEDIDO
(
	CODEPED		int							not null,
	BARCODE		char(20)					not null,

	CANTIDAD	tinyint						not null,

	constraint PK_ITEMPEDIDO primary key (CODEPED, BARCODE),

	constraint FK_PRODUCTO_SOLICITADO_PEDIDO foreign key (CODEPED) references PEDIDO (CODEPED),
	constraint FK_PEDIDO_REGISTRA_PRODUCTO foreign key (BARCODE) references PRODUCTO (BARCODE)
);

create table ITEMCOMPRA
(
	CODECOM		int							not null,
	BARCODE		char(20)					not null,

	CANTIDAD	tinyint						not null,

	constraint PK_ITEMCOMPRA primary key (CODECOM, BARCODE),

	constraint FK_PRODUCTO_COMPRADO_COMPRA foreign key (CODECOM) references COMPRA (CODECOM),
	constraint FK_COMPRA_FACTURA_PRODUCTO foreign key (BARCODE) references PRODUCTO (BARCODE)
);