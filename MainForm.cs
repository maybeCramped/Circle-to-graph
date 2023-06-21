/*
 * Created by SharpDevelop.
 * User: IDEAD PAD 330S
 * Date: 08/09/2019
 * Time: 09:54 a. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Actividad1
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	
	public partial class MainForm : Form
	{
		Grafo G;
		Bitmap original;
		Bitmap copia;
		Bitmap copia2;
		Bitmap copia3;
		bool bandera=false;
		List<Circle> L=new List<Circle>();
		int id;
		public void animar(int x, int y,SolidBrush b){
            Graphics lol = Graphics.FromImage(copia3);
            lol.Clear(Color.Transparent);
            lol.FillEllipse(b,x-14, y-14, 29, 29);
			pictureBoxResultado.Refresh();
			//Thread.Sleep(10);
		}
		public void anima(hamiltonian h, SolidBrush br)
        {
			edge a=new edge ();
			while(h.getCont()>0){
			a=h.pop();
			double x_o=a.getOrigen().getCentroX(), x_d= a.getVertex().getCentroX(), y_o= a.getOrigen().getCentroY(), y_d=a.getVertex().getCentroY(),M,b;
			M= a.getM();
			b= a.getB();
			double inc;
			inc=10;
			if(x_d==x_o){
				double x=x_o;
				if(y_o>y_d)
					inc=-10;
				for(double j= y_o;j*inc<y_d*inc;j+=inc){
					animar((int)Math.Round(x),(int) Math.Round(j),br);
				}
					
				
			} else
			if(M>1||M<-1){
				double x;
				if(y_o>y_d)
					inc=-10;
				double j=y_o;
				for( ; j * inc < y_d * inc; j+=inc){
					x=(b-j)/-M;
					animar((int)Math.Round(x),(int) Math.Round(j),br);
				}
				
			}else{
			
				if(x_o>x_d)
				inc=-10;
			double y; 
			for(double i=x_o;i*inc<x_d*inc;i=i+inc){
				y=M*i+b;
				animar((int)Math.Round(i),(int)Math.Round(y),br);
			}
			}
                animar(a.getVertex().getCentroX(), a.getVertex().getCentroY(), br);
		}
	}
		public Point calculaZoom(MouseEventArgs e){
            
			int X, Y;
			int w_i = pictureBoxResultado.Image.Width; 
            int h_i = pictureBoxResultado.Image.Height;
            int w_c = pictureBoxResultado.Width;
            int h_c = pictureBoxResultado.Height;
            float imageRatio = w_i / (float)h_i;
            float containerRatio = w_c / (float)h_c; 

            if (imageRatio >= containerRatio)
            {
                float scaleFactor = w_c / (float)w_i;
                float scaledHeight = h_i * scaleFactor;
                float filler = Math.Abs(h_c - scaledHeight) / 2;  
                X = (int)(e.X / scaleFactor);
                Y = (int)((e.Y - filler) / scaleFactor);
            }
            else
            {
                float scaleFactor = h_c / (float)h_i;
                float scaledWidth = w_i * scaleFactor;
                float filler = Math.Abs(w_c - scaledWidth) / 2;
             	X = (int)((e.X - filler) / scaleFactor);
               	Y = (int)(e.Y / scaleFactor);
            }
            Point p=new Point(X,Y);
            return p;
		}
		public void borrarCirculo(int x, int y, int pos){
			for(int i=0;!isWhite(copia.GetPixel(x+i,y));i++){
				for(int j=0;!isWhite(copia.GetPixel(x+i,y+j));j++){
					copia.SetPixel(x-i,y-j, Color.White);
				 	copia.SetPixel(x+i,y-j, Color.White);
				 	copia.SetPixel(x-i,y+j, Color.White);
				 	copia.SetPixel(x+i,y+j, Color.White);
				 	if(y+j+1>=copia.Height)
					break;
				}
			if(i+x+1>=copia.Width)
					break;
			}
			L.RemoveAt(pos);
		}
        public void creaGrafo() {
            bandera = true;
            treeView1.Nodes.Clear();
            listBoxCircles.DataSource = null;
            listBoxCircles.DataSource = L;
            copia2 = new Bitmap(copia);
            
			
            Graphics gr;
            gr = Graphics.FromImage(copia2);
            Pen pluma = new Pen(Color.Black, 2);
            vertex cer1 = new vertex();
            vertex cer2 = new vertex();
            double dis, x;
            dis = 0;
            G = new Grafo(L);
            int N = G.getCountVertex();
            if (N > 1) {
                cer1 = G.getVertexPos(0);
                cer2 = G.getVertexPos(1);
                dis = G.distancia(cer1, cer2);

            }
            for (int i = 0; i < N; i++) {
                vertex o = G.getVertexPos(i);
                for (int j = i + 1; j < N; j++) {
                    vertex d = G.getVertexPos(j);
                    if (N > 1) {
                        x = G.distancia(o, d);
                        if (dis > x) {
                            dis = x;
                            cer1 = o;
                            cer2 = d;
                        }
                    }
                    if (o.tryEdge(d, copia)) {
                        gr.DrawLine(pluma, (float)o.getCentroX(), (float)o.getCentroY(), (float)d.getCentroX(), (float)d.getCentroY());
                        o.addEdge(o, d);
                        d.addEdge(d, o);
                    }
                }
            }
            if (N > 1)
                G.setPar(cer1, cer2, dis);
            pictureBoxResultado.BackgroundImage = copia2;
             copia3 = new Bitmap(copia2);
			pictureBoxResultado.Image = copia3;
			for(int i=0;i<G.getCountVertex();i++){
				treeView1.Nodes.Add(G.getVertexPos(i).getId().ToString());
				for(int j=0;j<G.getVertexPos(i).getCount();j++){
					treeView1.Nodes[i].Nodes.Add(G.getVertexPos(i).getEdgePos(j).getVertex().getId().ToString());
				}
			}
			
		}
		public bool isBlue(Color c){
			if (c.R==0)
				if(c.G==0)
					if(c.B==255)
						return true;
			return false;
			
		}
		public bool isBlack(Color c){
			if (c.R==0)
				if(c.G==0)
					if(c.B==0)
						return true;
			return false;
			
		}
		public bool isWhite(Color c){
			if (c.R==255)
				if(c.G==255)
					if(c.B==255)
						return true;
			return false;
		}
		
		void drawCenter(Circle c){
			int x,y;
			x=c.getCentroX();
				y=c.getCentroY();
			for(int i=-2;i<3;i++ )
				for(int j=-2;j<3;j++)
					copia.SetPixel(x+j,y+i,Color.Green);
					
			
		}
		
		void borrarElipse(Circle c,int xi,int xf,Color a){
			int x=c.getCentroX();
			int y=c.getCentroY();
			for(int j=xi;j<=xf;j++){
                int yf = y, yi = y;
                while (!isWhite(copia.GetPixel( j,yi)))
					yi--;
				while(!isWhite(copia.GetPixel( j,yf)))
					yf++;
				for(int i = yi; i<=yf;i++)
					copia.SetPixel(j,i,a);
				}
				
				

		}
		void DrawCircle(Circle c){
			int i, j, x, y;
			x=c.getCentroX();
			y=c.getCentroY();
			
			for(i=0;!isWhite(copia.GetPixel(x+i,y));i++){
				for(j=0;!isWhite(copia.GetPixel(x+i,y+j));j++){
					copia.SetPixel(x-i,y-j, Color.Blue);
				 	copia.SetPixel(x+i,y-j, Color.Blue);
				 	copia.SetPixel(x-i,y+j, Color.Blue);
				 	copia.SetPixel(x+i,y+j, Color.Blue);
				 	if(y+j+1>=copia.Height)
					break;
				}
			if(i+x+1>=copia.Width)
					break;
			}
				
		}
		void pintaCercanos(vertex c){
			int i, j, x, y;
			x=c.getCentroX();
			y=c.getCentroY();
			
			for(i=0;!isWhite(copia.GetPixel(x+i,y));i++){
				for(j=0;!isWhite(copia.GetPixel(x+i,y+j));j++){
					if(isBlue(copia2.GetPixel(x-i,y-j)))
						copia2.SetPixel(x-i,y-j, Color.Purple);
					if(isBlue(copia2.GetPixel(x+i,y-j)))
					 	copia2.SetPixel(x+i,y-j, Color.Purple);
					if(isBlue(copia2.GetPixel(x-i,y+j)))
						copia2.SetPixel(x-i,y+j, Color.Purple);
					if(isBlue(copia2.GetPixel(x+i,y+j)))
						copia2.SetPixel(x+i,y+j, Color.Purple);
				 	if(y+j+1>=copia.Height)
					break;
				}
			if(i+x+1>=copia.Width)
					break;
			}
		}
		void findCenter(int x, int y){
			int x_i=x, x_f=x, y_i=y, y_f=y,y_c,x_c,r,rY, rX,cont;
			
			cont=y_i;
			while(!isWhite(copia.GetPixel(x_i,cont))){
				cont--;
				if(cont==0)
					return;
			}
			
          cont++;
			y_i=cont;
			
			
			while(!isWhite(copia.GetPixel(x_i,y_f))){
				y_f++;
				if(y_f>=copia.Height)
					return;
			}
			y_f--;
			y_c=(y_i+y_f)/2;
			
			while(!isWhite(copia.GetPixel(x_i,y_c))){
				x_i--;
				if(x_i==0)
					return;
			}
			x_i++;
			if(x_f<=0||x_f>=copia.Width)
				return;
			if(y_c<=0)
				return;
			while(!isWhite(copia.GetPixel(x_f,y_c))){
				x_f++;
				if(x_f>=copia.Width)
					return;
			}
			x_f--;
			x_c=(x_i+x_f)/2;
			rY=y_c;
			while(!isWhite(copia.GetPixel(x_c,rY))){
				rY--;
			}
			rY++;
			rY=y_c-rY;
			rX=x_c-x_i;
			r=rY;
			if(r<rX)
				r=rX;
			Circle c= new Circle(id+1,x_c,y_c, r);
			if(rY-rX>5||rY-rX<-5){
				borrarElipse(c, x_i, x_f, Color.White);
				return;
			}
			
			id++;
			L.Add(c);
			borrarElipse(c, x_i, x_f, Color.Blue);
			drawCenter(c);
		}
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			
			InitializeComponent();
			id=0;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void ButtonCargarClick(object sender, EventArgs e)
		{
            listBoxCircles.DataSource = null;
            treeView1.Nodes.Clear();
            buttonOrdena.Visible = false;
            buttonParCercano.Visible = false;
            Circuito.Visible=false;
			id=0;
			openFileDialog1.Filter="Archivos PNG(*.png)|*.png|JPEG(*.jpg)|*.jpg ";
            /*openFileDialog1.InitialDirectory="C:\\";*/
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBoxImagen.ImageLocation = openFileDialog1.FileName;
                buttonAnalizar.Visible = true;

            }
            else
            {
                buttonAnalizar.Visible = false;
                pictureBoxImagen.ImageLocation = null;
                pictureBoxResultado.Image = null;

                bandera = false;
            }
		}
		void ButtonAnalizarClick(object sender, EventArgs e)
		{
			L.Clear();
			id=0;
			original= new Bitmap(openFileDialog1.FileName);
			copia = new Bitmap(original);
			for(int j = 0; j<copia.Height;j++){
				for(int i = 0; i<copia.Width;i++){
					if (isBlack(copia.GetPixel(i,j))){
						findCenter(i,j);
					}
				}
			}
			
			creaGrafo();
            buttonOrdena.Visible = true;
            buttonParCercano.Visible = true;
        }
		void ButtonParCercanoClick(object sender, EventArgs e)
		{
			if(G.getCountVertex()<2)
				return;
			pintaCercanos(G.getPar1());
			pintaCercanos(G.getPar2());
			pictureBoxResultado.Image=copia2;
		}
		void ButtonOrdenaClick(object sender, EventArgs e)
		{
			Circle c=new Circle();
			int n= L.Count-1;
			for(int i= 0;i<n;i++){
				int menor=i;
				for(int j=i+1;j<=n;j++){
					if(L[menor].getRadio()>L[j].getRadio()){
						menor=j;
					}
				}
						c=L[i];
						L[i]=L[menor];
						L[menor]=c;
						G.swap(i,menor);
			}
			listBoxCircles.DataSource=null;
			listBoxCircles.DataSource=L;
		}
		void TreeView1NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
		}
		void PictureBoxResultadoClick(object sender, EventArgs e)
		{
		}
		void PictureBoxResultadoMouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button== MouseButtons.Left)
				return;
            if (!bandera)
                return;
            Point p=calculaZoom(e);
			int X = p.X, Y=p.Y;
			
            int cont= G.getCountVertex();
            int x,y;
            int distanciap;
            float distancia;
            for(int i=0;i<cont;i++){
            	vertex a=G.getVertexPos(i);
            	x=a.getCentroX();
            	y=a.getCentroY();
            	distanciap=(x-X)*(x-X)+(y-Y)*(y-Y);
            	distancia= (float)Math.Sqrt(distanciap);
            	if(distancia<=a.getRadio()+4){
            		borrarCirculo(x,y,i);
            		creaGrafo();
            		return;
            	}
            	
            	
            }
		}
		void PictureBoxResultadoMouseMove(object sender, MouseEventArgs e)
		{
			if(!bandera)
				return;
			Point p=calculaZoom(e);
			int X = p.X, Y=p.Y;
            int cont= G.getCountVertex();
            int x,y;
            int distanciap;
            float distancia;
            bool ban=false;
            for(int i=0;i<cont;i++){
            	vertex a=G.getVertexPos(i);
            	x=a.getCentroX();
            	y=a.getCentroY();
            	distanciap=(x-X)*(x-X)+(y-Y)*(y-Y);
            	distancia= (float)Math.Sqrt(distanciap);
            	if(distancia<=a.getRadio()+4){
            		IdCirculo.Text="ID Actual: "+ a.getId();
            		ban=true;
            		break;
            	}
            } if (!ban)
            	IdCirculo.Text=null;
		}
        public void hmlt(edge e, Stack<vertex> pila, List<hamiltonian> le, List <hamiltonian> sub)
        {
        	int contH=le.Count;
        	int contg= sub.Count;
        	vertex d = e.getVertex();
        	pila.Push(d);
        	if(d==G.getInicioHmlt()){
        		if(pila.Count==G.getCountVertex()){
        			hamiltonian h= new hamiltonian();
        			le.Add(h);
        			pila.Pop();
        			return ;
        		}
        		hamiltonian g= new hamiltonian();
        		sub.Add(g);
        		pila.Pop();
        		return;
        	}
        	if(pila.Count==G.getCountVertex()){
        		pila.Pop();
        		return;
        	}
        	
        	for (int i = 0; i < d.getCount(); i++)
            {
        		
        		edge prueba= d.getEdgePos(i);
        		if(!pila.Contains(prueba.getVertex())){
        			hmlt(d.getEdgePos(i), pila, le,sub);
        			while(contH<le.Count){
        					le[contH].add(prueba);
        					contH++;
        		}
        			while(contg<sub.Count){
        					sub[contg].add(prueba);
        					contg++;
        		}
        		
            	}
        	}
        	pila.Pop();
        	return ;
        	
        }
        private void Circuito_Click(object sender, EventArgs e)
        {
        	int cont =0,contg=0;
            vertex a = G.getInicioHmlt();
            Stack<vertex> pila= new Stack<vertex>();
            List<hamiltonian> Le = new List<hamiltonian>();
            List<hamiltonian> sub = new List<hamiltonian>();
            for (int i= 0; i < a.getCount(); i++)
            {
            	edge ed=a.getEdgePos(i);
            	hmlt(a.getEdgePos(i), pila, Le,sub);
                while(cont<Le.Count){
                	Le[cont++].add(ed);
                }while(contg<sub.Count){
        					sub[contg].add(ed);
        					contg++;
        		}
            }
            if(Le.Count==0){
            	Le.Clear();
            	Le.Add(sub[0]);
            	for(int i=1; i<sub.Count;i++){
            		if(sub[i].getCont()<Le[0].getCont()){
            		}else if(sub[i].getCont()>Le[0].getCont()){
            			Le.Clear();
            			Le.Add(sub[i]);
            		}else
            			Le.Add(sub[i]);
            	}
            }
            if(Le.Count>1)
            Le.Sort(hamiltonian.CompareHamil);
           
            Random r=new Random();
            List<Color> l=new List<Color>();
            l.Add(Color. Red);
            l.Add(Color.LemonChiffon);
            l.Add(Color. Yellow);
            l.Add(Color. Orange);
            l.Add(Color. Pink);
            SolidBrush b = new SolidBrush(Color.Red);
            for (int i=0;i<Le.Count;i++){
                b.Color = l[r.Next(1, 5)];
                anima(Le[i],b);
            }
            
        }

        private void pictureBoxResultado_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!bandera)
                return;
			pictureBoxResultado.Image = copia3;
            Circuito.Visible=true;
            Point p = calculaZoom(e);
            int X = p.X, Y = p.Y;
            int cont = G.getCountVertex();
            int x, y;
            int distanciap;
            float distancia;
            for (int i = 0; i < cont; i++)
            {
                vertex a = G.getVertexPos(i);
                x = a.getCentroX();
                y = a.getCentroY();
                distanciap = (x - X) * (x - X) + (y - Y) * (y - Y);
                distancia = (float)Math.Sqrt(distanciap);
                if (distancia <= a.getRadio() + 4)
                {
                    G.setInicioHmlt(a);
                    break;
                }
            }       
        }
    }
    public class Grafo{
		vertex parCercano1;
		vertex parCercano2;
        vertex inicioHmlt;
		double separacion;
		List<Grafo> subgrafo;
		public void calculaSub(vertex a){
			
			Grafo g = new Grafo();
			for(int i= 0; i<a.getCount();i++){
				
			}
			
		}
        public vertex getInicioHmlt()
        {
            return inicioHmlt;
        }
        public void setInicioHmlt(vertex a)
        {
            inicioHmlt = a;
        }
		public void vaciar(){
			LVertex.Clear();
		}
		public void swap(int pos, int posn){
			vertex a;
			a=LVertex[pos];
			LVertex[pos]=LVertex[posn];
			LVertex[posn]=a;
		}
		public vertex getPar1(){
			return parCercano1;
		}
		public vertex getPar2(){
			return parCercano2;
		}
		public Grafo(){
			
		}
		public vertex getVertexPos(int i){
			return LVertex[i];
		}
		public double distancia(vertex a,vertex b){
			double d;
			double x_1=a.getCentroX(),x_2=b.getCentroX(),y_1=a.getCentroY(),y_2=b.getCentroY();
			d= Math.Sqrt((x_2-x_1)*(x_2-x_1)+(y_2-y_1)*(y_2-y_1));
			return d;
		}
		public Grafo(List<Circle> c){
			for(int i=0; i<c.Count;i++){
				vertex v= new vertex(c[i]);
				LVertex.Add(v);
				
			}
        	subgrafo=new List<Grafo>();
		}
		public void setPar(vertex a, vertex b,double d){
			parCercano1=a;
			parCercano2=b;
			separacion=d;
		}
		List<vertex> LVertex=new List<vertex>();
		public int getCountVertex(){
			return LVertex.Count;
		}
		
	}
	public class Circle{
		int id;
		int centroX;
		int centroY;
		int radio;
		public override string ToString()
		{
			return string.Format("[Id={0} Centro({1},{2}) Radio={3}]", id, centroX, centroY, radio);
		}
		public Circle(){
		}
		public Circle(int i, int x, int y, int radio){
			centroX=x;
			centroY=y;
			this.radio=radio;
			id=i;
		}
		public int getCentroX(){
			return this.centroX;
		}
		public int getCentroY(){
			return this.centroY;
		}
		public int getRadio(){
			return this.radio;
		}
		public int getId(){
			return this.id;
		}
	}
	public class vertex{
		public int getRadio(){
			return c.getRadio();
		}
		public bool isBlue(Color c){
			if (c.R==0)
				if(c.G==0)
					if(c.B==255)
						return true;
			return false;
			
		}
		public bool isBlack(Color c){
			if (c.R==0)
				if(c.G==0)
					if(c.B==0)
						return true;
			return false;
			
		}
		public bool isWhite(Color c){
			if (c.R>=245)
				if(c.G>=245)
					if(c.B>=245)
						return true;
			return false;
		}
		Circle c;
		List<edge> LEdges;
		public vertex(){
		}
		public vertex(Circle c){
			this.c=c;
			LEdges=new List<edge>();
		}
		public int getId(){
			return c.getId();
		}
		public int getCount(){
			return LEdges.Count;
		}
		public edge getEdgePos(int i){
			return LEdges[i];
		}
		public int getCentroX(){
			return c.getCentroX();
		}
		public int getCentroY(){
			return c.getCentroY();
		}
		public void addEdge(vertex o, vertex d){
			edge e= new edge(o,  d);
			LEdges.Add(e);
		}
		public bool tryEdge(vertex d,Bitmap B){
			double x_o=c.getCentroX(), x_d= d.getCentroX(), y_o= c.getCentroY(), y_d=d.getCentroY(),M,b;
			int bandera=0;
			double inc;
			Color C;
			inc=1;
			if(x_d==x_o){
				double x=x_o;
				if(y_o>y_d)
					inc=-1;
				for(double j= y_o;j!=y_d;j+=inc){
					C=B.GetPixel((int)Math.Round(x),(int) Math.Round(j));
					if(bandera==0){
						if(isWhite(C)){
							bandera++;						
							continue;
						}
					}
				if(bandera==1){
					if(!isWhite(C)){
						if(!isBlue(C))
							return false;
						bandera++;
						continue;
					}
				}
				if(bandera==2){
					if(isWhite(C))
						return false;
				}
				}
					
				return true;
			}
			M= (y_d-y_o)/(x_d-x_o);
			b= y_o-M*x_o;
			
			if(M>1||M<-1){
				double x;
				if(y_o>y_d)
					inc=-1;
				double j=y_o;
				for( ;j!=y_d;j+=inc){
					x=(b-j)/-M;
					C=B.GetPixel((int)Math.Round(x),(int) Math.Round(j));
					if(bandera==0){
							if(isWhite(C)){
						bandera++;
						continue;
					}
				}
				if(bandera==1){
					if(!isWhite(C)){
						if(!isBlue(C))
							return false;
						bandera++;
						continue;
					}
						if(!isWhite(B.GetPixel((int)Math.Round(x+inc),(int) Math.Round(j)))){
							if(!isWhite(B.GetPixel((int)Math.Round(x),(int) Math.Round(j+inc)))){
								if(isBlue(B.GetPixel((int)Math.Round(x+inc),(int) Math.Round(j))))		
									if(isBlue(B.GetPixel((int)Math.Round(x),(int) Math.Round(j+inc)))){
									bandera++;
									continue;
								}
								return false;
								
							}
						}
				}
				if(bandera==2){
					if(isWhite(C))
						return false;
				}
				}
				return true;
			}
			
			if(x_o>x_d)
				inc=-1;
			double y; 
			for(double i=x_o;i!=x_d;i=i+inc){
				y=M*i+b;
				C=B.GetPixel((int)Math.Round(i),(int)Math.Round(y));
				if(bandera==0){
					if(isWhite(C)){
						bandera++;
						continue;
					}
				}
				if(bandera==1){
					if(!isWhite(C)){
						if(!isBlue(C))
							if(!isBlue(B.GetPixel((int)Math.Round(i+1),(int)Math.Round(y))))
							return false;
						bandera++;
						continue;
					}
					if(!isWhite(B.GetPixel((int)Math.Round(i+inc),(int) Math.Round(y)))){
							if(!isWhite(B.GetPixel((int)Math.Round(i),(int) Math.Round(y+inc)))){
								if(isBlue(B.GetPixel((int)Math.Round(i+inc),(int) Math.Round(y))))		
									if(isBlue(B.GetPixel((int)Math.Round(i),(int) Math.Round(y+inc)))){
									bandera++;
									continue;
								}
								return false;
								
							}
						}
				}
				if(bandera==2){
					if(isWhite(C))
						return false;
				}
			}
			return true;
				
			
		}
		
		
	}
	public class hamiltonian{
	Stack<edge> camino;
	double distancia;
	public static int CompareHamil(hamiltonian x, hamiltonian y)
    {
		int a=1;
		if(x.distancia<y.distancia)
			a=-1;
			return a;
	}
	public int getCont(){
		return camino.Count;
	}
	public hamiltonian(){
		camino=new Stack<edge>();
		distancia= 0;
	}
	public edge pop(){
		return camino.Pop();
	}
	
	public void add(edge e){
		camino.Push(e);
		distancia += e.getDistancia();
	}
}
	public class edge{
		vertex origen;
		vertex destino;
		double m;
        int b;
        double distancia;
		public edge(){
			
		}
		public edge(vertex o, vertex d){
			origen=o;
			destino= d;
			int x_1, x_2, y_1, y_2;
			x_1= origen.getCentroX();
			y_1= origen.getCentroY();
			x_2= destino.getCentroX();
			y_2= destino.getCentroY();
			m= (y_2-y_1)*1.0/(x_2-x_1);
			if (x_2-x_1==0)
				m=0;
            b = y_1 - (int)Math.Round(m * x_1);
            distancia= Math.Sqrt(Math.Pow(x_2-x_1,2)+Math.Pow(y_2-y_1,2));
        }
		public vertex getVertex(){
			return destino;
		}
        public vertex getOrigen()
        {
            return origen;
        }
        public double getDistancia(){
        	return distancia;
        }
        public double getM(){
        	return m;
        }
        public int getB(){
        	return b;
        }
	}
}

