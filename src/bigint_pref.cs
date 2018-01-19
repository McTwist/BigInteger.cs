

exec("./bigint.cs");

function bigintpref_add()
{
	%amount = 16384;

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_add(500, 150);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("500 + 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_add(1500, 2500);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("1500 + 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_add("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475", "1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_add2()
{
	%amount = 16384;

	%a = BigInt(500);
	%b = BigInt(150);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.add(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("500 + 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt(1500);
	%b = BigInt(2500);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.add(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("1500 + 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475");
	%b = BigInt("1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.add(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_subtract()
{
	%amount = 16384;

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_subtract(500, 150);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("500 - 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_subtract(1500, 2500);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("1500 - 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_subtract("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475", "1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_subtract2()
{
	%amount = 16384;

	%a = BigInt(500);
	%b = BigInt(150);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.subtract(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("500 - 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt(1500);
	%b = BigInt(2500);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.subtract(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("1500 - 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475");
	%b = BigInt("1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.subtract(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_multiply()
{
	%amount = 16384;

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_multiply(500, 150);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("500 * 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_multiply(1500, 2500);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("1500 * 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%amount = 2048;
	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_multiply("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475", "1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_multiply2()
{
	%amount = 16384;

	%a = BigInt(500);
	%b = BigInt(150);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.multiply(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("500 * 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt(1500);
	%b = BigInt(2500);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.multiply(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("1500 * 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475");
	%b = BigInt("1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");

	%amount = 2048;
	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.multiply(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_div()
{
	%amount = 16384;

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_divmod(500, 150);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("500 / 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_divmod(1500, 2500);
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("1500 / 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%amount = 2048;
	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		bigint_divmod("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475", "1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");
	}
	%end = getRealTime();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_div2()
{
	%amount = 16384;

	%a = BigInt(500);
	%b = BigInt(150);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.divmod(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("500 / 150: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt(1500);
	%b = BigInt(2500);

	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.divmod(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("1500 / 2500: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");

	%a = BigInt("9483049584726374829384728377323947585720345827309682730496827304968273049682730940680298344509283475");
	%b = BigInt("1981724981245897126895716298751692875691827365918369867227365981723659823627272721726598172635981726");

	%amount = 2048;
	%start = getRealTime();
	for (%i = 0; %i < %amount; %i++)
	{
		%a.divmod(%b);
	}
	%end = getRealTime();

	%a.delete();
	%b.delete();

	%time = %end - %start;
	echo("100 digits: " @ %time @ "ms  avg: " @ (%time / %amount) @ "ms");
}

function bigintpref_all()
{
	echo("All do 16 384 iterations");
	echo("");
	echo("Add with strings");
	bigintpref_add();
	echo("Add without strings");
	bigintpref_add2();
	echo("");
	echo("Subtract with strings");
	bigintpref_subtract();
	echo("Subtract without strings");
	bigintpref_subtract2();
	echo("");
	echo("Multiply with strings (last does 2 048)");
	bigintpref_multiply();
	echo("Multiply without strings (last does 2 048)");
	bigintpref_multiply2();
	echo("");
	echo("Div with strings (last does 2 048)");
	bigintpref_div();
	echo("Div without strings (last does 2 048)");
	bigintpref_div2();
}
