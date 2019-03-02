using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JorgenFinal
{
    class ObjectScroll
    {
        //Varibler
        int scroll;
        Vector2 size;
        Texture2D texture;
        Vector2 position;
        float speed;
        Rectangle rect;
        //Get/Set
        public int Scroll
        {
            get
            { return scroll; }
            set
            { scroll = value; }
        }
        public Vector2 Position
        {
            get
            { return position; }
            set
            { position = value; }
        }
        public Vector2 Size
        {
            get
            { return size; }
            set
            { size = value; }
        }
        public Rectangle Rect
        {
            get
            { return rect; }
            set
            { rect = value; }
        }
        public Texture2D Texture
        {
            get
            { return texture; }
            set
            { texture = value; }
        }
        //Constructor
        public ObjectScroll(Texture2D texture, Vector2 position, Vector2 size, int scroll, float speed)
        {
            this.texture = texture;
            this.position = position;
            this.size = size;
            this.scroll = scroll;
            this.speed = speed;
        }

        public void Update()
        {

            //object position + 
            rect = new Rectangle(((int)position.X + (int)(scroll * speed)), (int)position.Y, (int)size.X, (int)size.Y);

        }

    }
}
