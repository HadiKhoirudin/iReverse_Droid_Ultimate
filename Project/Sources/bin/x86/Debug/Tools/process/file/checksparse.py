import sys  
import struct  
import os
class ext4_file_header:  
    def __init__(self, buf):  
        self.magic, \
                self.major, \
                self.minor, \
                self.file_header_size, \
                self.chunk_header_size, \
                self.block_size, \
                self.total_blocks, \
                self.total_chunks, \
                self.crc32, \
                = struct.unpack('<IHHHHIIII', buf)  
  
class ext4_chunk_header:  
    def __init__(self, buf):  
        self.type,\
                self.reserved,\
                self.chunk_size,\
                self.total_size,\
                = struct.unpack('<HHII', buf)  
  
if len(sys.argv) > 1:  
    filename = sys.argv[1]  
else:  
    print ("No file is designated")
    sys.exit(1)
ifd = open(filename, "rb")
arane = os.path.basename(ifd.name)
#buf=
  
# get filelen  
ifd.seek(0, 2)  
file_len = ifd.tell()  
print ("file_len")
ifd.seek(0, 0)  
  
buf = ifd.read(28)  
#print repr(buf)  
file_header = ext4_file_header(buf)  
  
EXT4_FILE_HEADER_MAGIC = 0xED26FF3A  
EXT4_CHUNK_HEADER_SIZE = 12  
  
if file_header.magic != EXT4_FILE_HEADER_MAGIC:  
    print ("not sparse")
    sys.exit(1)
  
#print "file_header chunks:%X%" % (file_header.total_chunks)
  
total_chunks = file_header.total_chunks  
#print "total chunk = %d" %(total_chunks)
  
#ofd = open("unsparse.img", "wb")

sector_base = 82528  
output_len = 0  
  
while total_chunks > 0:  
    buf = ifd.read(EXT4_CHUNK_HEADER_SIZE)  
    chunk_header = ext4_chunk_header(buf)  
    sector_size = (chunk_header.chunk_size * file_header.block_size) >> 9;  
    #print ct:%X, cs:%X, ts:%X, ss:%X%(chunk_header.type, chunk_header.chunk_size, chunk_header.total_size, sector_size)  
  
  #data =
    if chunk_header.type == 0xCAC1:  # raw type   
        data = ifd.read(chunk_header.total_size - EXT4_CHUNK_HEADER_SIZE)  
        if len(data) != (sector_size << 9):  
            print ("len sector_size:%d" % ( (sector_size << 9)))
            sys.exit(1)  
        else:  
           # print " sector_size:%d" % ( sector_size << 9)
           kfd = open("%d.sparse" % (total_chunks) , "wb")
           kfd.write(data)
           # ofd.write(data)  
           # output_len += len(data)  
            
            #print raw_chunk
           print ('<sector="'+'%d' % (sector_size)+'"' , 'filename="' + '%d.sparse' % (total_chunks) +'"' , '/>')
            #print "output len:%x" % (output_len)
          
          #  sector_base += sector_size  
    else:  
        if chunk_header.type == 0xCAC2:  # TYPE_FILL  
            data = '\0' * (sector_size << 9); 
           # kfd = open("%d.sparse" % (total_chunks), "wb")
           # kfd.write(data)
           # ofd.write(data)   
            #output_len += len(data)  
            #print fill_chunk % n
            #print "chunk_size:%x" % (chunk_header.chunk_size)
            #print "output len:%x" % (output_len)
            print ('<sector="'+'%d' % (sector_size)+'"' , 'filename="''"' , '/>')
          
          #  sector_base += sector_size  
        else:  
            if chunk_header.type == 0xCAC3:  # TYPE_DONT_CARE  
                #print none chunk at chunk:%d%(file_header.total_chunks - total_chunks)
                #print(data_size:0x%x, chunk_size:%d, block_size:%d%(sector_size << 9, chunk_header.chunk_size, file_header.block_size))
              # data = ('\0' * (sector_size << 9)).encode('utf-8')
              # ofd.write(data)   
                # kfd = open("%d.sparse" % (total_chunks), "wb")
                # kfd.write(data)
                #output_len += len(data)  
                #sector_base += sector_size  
               print ('<sector="'+'%d' % (sector_size)+'"' , 'filename="''"' , '/>')
          
            else:  
                #data = '\0' * (sector_size << 9)
                #kfd = open("%d.sparse"% (total_chunks), "wb")
               # kfd.write(data)
               # ofd.write(data)  
                #print unknown typeecho                  output_len += len(data)
                #print(output len:%x%(output_len))
                print ('<sector="'+'%d' % (sector_size)+'"' , 'filename="''"' , '/>')
          
                #sector_base += sector_size  
  
    total_chunks -= 1   
  #  print "remain chunks = %d" % (total_chunks)
  
print( "write done")
  
ifd.close()  
#ofd.close()  
kfd.close() 
