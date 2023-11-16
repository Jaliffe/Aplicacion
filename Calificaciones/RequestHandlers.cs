public static class RequestHandlers{
    public static IResult MostrarCalificaciones(){
        List<CalificacionMateria> list = new List<CalificacionMateria>();

        CalificacionMateria calculos = new CalificacionMateria();
        calculos.Calificacion = 10;
        calculos.Materia = "Programacion Orientada a Objetos";
        calculos.Parcial = 1;
        calculos.NumControl = 22328051051234;

        CalificacionMateria calculos2 = new CalificacionMateria();
        calculos2.Calificacion = 9;
        calculos2.Materia = "Programacion Orientada a Eventos";
        calculos2.Parcial = 1;
        calculos2.NumControl = 22328051051234;

        CalificacionMateria calculos3 = new CalificacionMateria();
        calculos3.Calificacion = 7.2;
        calculos3.Materia = "Biologia";
        calculos3.Parcial = 1;
        calculos3.NumControl = 22328051051234;

        CalificacionMateria calculos4 = new CalificacionMateria();
        calculos4.Calificacion = 8.2;
        calculos4.Materia = "Etica";
        calculos4.Parcial = 1;
        calculos4.NumControl = 22328051051234;

        CalificacionMateria calculos5 = new CalificacionMateria();
        calculos5.Calificacion = 7.9;
        calculos5.Materia = "Geometria";
        calculos5.Parcial = 1;
        calculos5.NumControl = 22328051051234;

        CalificacionMateria calculos6 = new CalificacionMateria();
        calculos6.Calificacion = 8.5;
        calculos6.Materia = "Tutoria";
        calculos6.Parcial = 1;
        calculos6.NumControl = 22328051051234;

        CalificacionMateria calculos7 = new CalificacionMateria();
        calculos7.Calificacion = 9.5;
        calculos7.Materia = "Ingles";
        calculos7.Parcial = 1;
        calculos7.NumControl = 22328051051234;

        CalificacionMateria c1 = new CalificacionMateria();
        c1.Calificacion = 8.8;
        c1.Materia = "Programacion orientada a objetos";
        c1.Parcial = 2;
        c1.NumControl = 22328051051234;

        CalificacionMateria c2 = new CalificacionMateria();
        c2.Calificacion = 6.9;
        c2.Materia = "Programacion orientada a eventos";
        c2.Parcial = 2;
        c2.NumControl = 22328051051234;

        CalificacionMateria c3 = new CalificacionMateria();
        c3.Calificacion = 7.8;
        c3.Materia = "Biologia";
        c3.Parcial = 2;
        c3.NumControl = 22328051051234;

        CalificacionMateria c4 = new CalificacionMateria();
        c4.Calificacion = 8.4;
        c4.Materia = "Etica";
        c4.Parcial = 2;
        c4.NumControl = 22328051051234;

        CalificacionMateria c5 = new CalificacionMateria();
        c5.Calificacion = 7.8;
        c5.Materia = "Geometria";
        c5.Parcial = 2;
        c5.NumControl = 22328051051234;

        CalificacionMateria c6 = new CalificacionMateria();
        c6.Calificacion = 9.3;
        c6.Materia = "Tutoria";
        c6.Parcial = 2;
        c6.NumControl = 22328051051234;

        CalificacionMateria c7 = new CalificacionMateria();
        c7.Calificacion = 8.9;
        c7.Materia = "Ingles";
        c7.Parcial = 2;
        c7.NumControl = 22328051051234;

        CalificacionMateria p1 = new CalificacionMateria();
        p1.Calificacion = 8.7;
        p1.Materia = "Programacion Orientada a Objetos";
        p1.Parcial = 3;
        p1.NumControl = 22328051051234;

        CalificacionMateria p2 = new CalificacionMateria();
        p2.Calificacion = 7.9;
        p2.Materia = "Programacion Orientada a Eventos";
        p2.Parcial = 3;
        p2.NumControl = 22328051051234;

        CalificacionMateria p3 = new CalificacionMateria();
        p3.Calificacion = 8.5;
        p3.Materia = "Biologia";
        p3.Parcial = 3;
        p3.NumControl = 22328051051234;

        CalificacionMateria p4 = new CalificacionMateria();
        p4.Calificacion = 9.0;
        p4.Materia = "Etica";
        p4.Parcial = 3;
        p4.NumControl = 22328051051234;
        
        CalificacionMateria p5 = new CalificacionMateria();
        p5.Calificacion = 7.9;
        p5.Materia = "Geometria";
        p5.Parcial = 3;
        p5.NumControl = 22328051051234;

        CalificacionMateria p6 = new CalificacionMateria();
        p6.Calificacion = 8.0;
        p6.Materia = "Tutoria";
        p6.Parcial = 3;
        p6.NumControl = 22328051051234;

        CalificacionMateria p7 = new CalificacionMateria();
        p7.Calificacion = 9.0;
        p7.Materia = "Ingles";
        p7.Parcial = 3;
        p7.NumControl = 22328051051234;

        list.Add(calculos);
        list.Add(calculos2);
        list.Add(calculos3);
        list.Add(calculos4);
        list.Add(calculos5);
        list.Add(calculos6);
        list.Add(calculos7);
        list.Add(c1);
        list.Add(c2);
        list.Add(c3);
        list.Add(c4);
        list.Add(c5);
        list.Add(c6);
        list.Add(c7);
        list.Add(p1);
        list.Add(p2);
        list.Add(p3);
        list.Add(p4);
        list.Add(p5);
        list.Add(p6);
        list.Add(p7);

        return Results.Ok(list);
    }
    public static IResult MostrarCalificacionesAlumno(long numControl,
    int parcial, bool soloAsignatura, bool soloAcreditadas){
    if(numControl == 22328051051234){
        List<CalificacionMateria> list = new List<CalificacionMateria>();
        CalificacionMateria m1 = new CalificacionMateria();
        m1.Calificacion = 10;
        m1.Materia = "Programacion Orientada a Objetos";
        m1.Parcial = 1;
        m1.NumControl = 22328051051234;

        list.Add(m1);
        return Results.Ok(list);
    }
    else{
        return Results.NotFound($"No existe un alumno con numero de control {numControl}");
    }
    }

}